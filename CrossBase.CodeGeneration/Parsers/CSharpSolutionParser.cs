using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using EnvDTE;
using EnvDTE80;
using CrossBase.CodeGeneration.Language;
using Attribute = CrossBase.CodeGeneration.Language.Attribute;
using Property = CrossBase.CodeGeneration.Language.Property;

namespace CrossBase.CodeGeneration.Parsers
{
    public class CSharpSolutionParser
    {
        public List<Interface> Interfaces { get; set; }
        public List<Class> Classes { get; set; }
        public List<Project> Projects { get; set; }
        public Dictionary<string, ProjectItem> ProjectItems { get; set; }
        private readonly DTE2 dte2;
        private Dictionary<Interface, List<CodeInterface2>> unresolvedInterfaces;
        private string logFile;
        private bool loggingEnabled;

        public ProjectItem GetProjectItem(string fileName)
        {
            var projectItem = ProjectItems[fileName];
            return projectItem;
        }


        public void DeleteAllGeneratedFiles()
        {
            var items = new List<ProjectItem>();
            foreach (var projectItem in ProjectItems.Values)
            {
                items.Add(projectItem);
                items.AddRange(Get(projectItem.ProjectItems));
            }

            var itemsToDelete = new List<ProjectItem>();
            foreach (var projectItem in items)
            {
                var fileName = projectItem.FileNames[0];
                if (fileName.EndsWith(".g.cs") || fileName.EndsWith(".g.dot") || fileName.EndsWith(".g.dot.svg") || fileName.EndsWith(".g.dot.png"))
                {
                    itemsToDelete.Add(projectItem);
                }
            }
            foreach (var projectItem in itemsToDelete)
            {
                projectItem.Delete();
            }
        }

        private static List<ProjectItem>Get(ProjectItems projectItems)
        {
            var items = new List<ProjectItem>();
            foreach (var projectItem in projectItems.Cast<ProjectItem>())
            {
                items.Add(projectItem);
                items.AddRange(Get(projectItem.ProjectItems));
            }
            return items;
        }

        private static List<ProjectItem> DeleteGeneratedFilesInProjectItems(ProjectItems projectItems)
        {
            var items = new List<ProjectItem>();
            foreach (var projectItem in projectItems.Cast<ProjectItem>())
            {
                try
                {
                    items.AddRange(DeleteGeneratedFilesInProjectItems(projectItem.ProjectItems));
                    if (projectItem.FileNames[0].EndsWith(".g.cs"))
                        items.Add(projectItem);
                }
                catch (Exception)
                {
                }
            }
            return items;
        }

        public List<Class> GetAllClassesThatContainPrivateFieldWithAnAttribute(string attributeName)
        {
            var results = new List<Class>();
            foreach (var @class in from @class in Classes
                                   from field in @class.Fields
                                   from attribute in field.Attributes
                                   where attribute.Name == attributeName
                                   where !results.Contains(@class)
                                   select @class)
            {
                results.Add(@class);
            }

            return results;
        }

        public List<Class> GetAllClassesThatHaveAnAttribute(string attributeName)
        {
            var results = new List<Class>();
            foreach (var @class in from @class in Classes
                                   from attribute in @class.Attributes
                                   where attribute.Name == attributeName
                                   where !results.Contains(@class)
                                   select @class)
            {
                results.Add(@class);
            }

            return results;
        }

        [DllImport("ole32.dll")]
        private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);
        [DllImport("ole32.dll")]
        private static extern void GetRunningObjectTable(int reserved, out IRunningObjectTable prot);

        private static DTE GetCurrent()
        {
            //rot entry for visual studio running under current process.
            string rotEntry = String.Format("!VisualStudio.DTE.11.0:{0}",
                                             System.Diagnostics.Process.GetCurrentProcess().Id);
            IRunningObjectTable rot;
            GetRunningObjectTable(0, out rot);

            IEnumMoniker enumMoniker;
            rot.EnumRunning(out enumMoniker);

            enumMoniker.Reset();
            var fetched = IntPtr.Zero;
            var moniker = new IMoniker[1];
            while (enumMoniker.Next(1, moniker, fetched) == 0)
            {
                IBindCtx bindCtx;
                CreateBindCtx(0, out bindCtx);
                string displayName;
                moniker[0].GetDisplayName(bindCtx, null, out displayName);
                if (displayName == rotEntry)
                {
                    object comObject;
                    rot.GetObject(moniker[0], out comObject);
                    return (DTE)comObject;
                }
            }
            return null;
        }

        public CSharpSolutionParser()
            :this(false)
        {
        }

        private void PrepareLogging()
        {
            loggingEnabled = false; //For debugging purposes set to true
            if (!loggingEnabled)
                return;

            const string logDir = "c:\\Temp";
            logFile = Path.Combine(logDir, "CrossBase.CodeGeneration.SolutionParser.log");
            if (Directory.Exists(logDir))
                return;
            Directory.CreateDirectory(logDir);

            if (File.Exists(logFile))
                File.Delete(logFile);
        }


        public CSharpSolutionParser(bool singleVsTesting)
        {
            if (singleVsTesting)
            {
                dte2 = (DTE2) Marshal.GetActiveObject("VisualStudio.DTE.11.0");
            }
            else
            {
                dte2 = (DTE2)GetCurrent();   
            }

            if (dte2 == null)
            {
                throw new Exception("T4Generator can only execute through the Visual Studio host");
            }

            PrepareLogging();
        }

        public void WriteLine(string value)
        {
            if (loggingEnabled)
                File.AppendAllText(logFile, value + Environment.NewLine);
        }

        public void ParseSolution()
        {
            Projects = new List<Project>();
            Interfaces = new List<Interface>();
            Classes = new List<Class>();
            ProjectItems = new Dictionary<string, ProjectItem>();
            unresolvedInterfaces = new Dictionary<Interface, List<CodeInterface2>>();
            WriteLine("ParseSolution " + dte2.Solution.FullName);


            Projects = new List<Project>();
            var item = dte2.Solution.Projects.GetEnumerator();
            while (item.MoveNext())
            {
                var project = item.Current as Project;
                if (project == null)
                {
                    continue;
                }



                if (project.Kind == "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}")
                {
                    Projects.AddRange(GetSolutionFolderProjects(project));
                }
                else
                {
                    Projects.Add(project);
                }
            }


            ParseProjects(Projects);
            ResolveInterfaceBases();

        }

        private void ResolveInterfaceBases()
        {
            while (unresolvedInterfaces.Count != 0)
            {
                var localCopyUnresolvedInterfaces = new Dictionary<Interface, List<CodeInterface2>>(unresolvedInterfaces);
                unresolvedInterfaces.Clear();
                foreach (var kv in localCopyUnresolvedInterfaces)
            {
                var @interface = kv.Key;
                foreach (var codeInterface in kv.Value)
                {
                    var @namespace = codeInterface.Namespace.Name;
                    var name = codeInterface.Name;
                    var baseInterface = Interfaces.Find(i => i.Namespace.Name == @namespace && i.Name == name);
                    if (baseInterface == null)
                    {
                        ParseInterface(codeInterface, new List<Namespace>(), new Namespace { Name = codeInterface.Namespace.Name }, string.Empty);
                        baseInterface = Interfaces.Find(i => i.Namespace.Name == @namespace && i.Name == name);

                    }
                    if (baseInterface != null)
                        @interface.InterfaceBases.Add(baseInterface);
                }
            }
            }
        }

        private static IEnumerable<Project> GetSolutionFolderProjects(Project solutionFolder)
        {
            var list = new List<Project>();
            for (var i = 1; i <= solutionFolder.ProjectItems.Count; i++)
            {
                var subProject = solutionFolder.ProjectItems.Item(i).SubProject;
                if (subProject == null)
                {
                    continue;
                }

                // If this is another solution folder, do a recursive call, otherwise add
                if (subProject.Kind == "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}")
                {
                    list.AddRange(GetSolutionFolderProjects(subProject));
                }
                else
                {
                    list.Add(subProject);
                }
            }

            return list;
        }

        public void ParseProject(string name)
        {
            Interfaces = new List<Interface>();
            Classes = new List<Class>();
            var project = dte2.Solution.Projects.Cast<Project>().FirstOrDefault(pro => pro.Name == name);

            if (project == null)
            {
                WriteLine("Project " + name + " not found!");
                return;
            }

            WriteLine("ParseProject " + name);
            ParseProject(project);
        }


        private void ParseProjects(List<Project> projects)
        {
            WriteLine("ParseProjects " + projects.Count);

            foreach (var project in projects)
            {
                ParseProject(project);                       
            }
        }

        private void ParseProject(Project project)
        {
            if (project == null)
                return;
            WriteLine("ParseProject " + project.Name);
            ParseProjectItems(project.ProjectItems);
        }

        private void ParseProjectItems(ProjectItems projectItems)
        {
            if (projectItems == null)
                return;
            WriteLine("ParseProjectItems " + projectItems.Count);

            foreach (var item in projectItems.Cast<ProjectItem>())
            {
                ParseProjectItem(item);
            }
        }

        private void ParseProjectItem(ProjectItem projectItem)
        {
            if (projectItem == null)
                return;

            switch (projectItem.Kind)
            {
                case "{6BB5F8EE-4483-11D3-8BCF-00C04F8EC28C}":
                    WriteLine("ParseProjectItem vsProjectItemKindPhysicalFile");
                    ParseFile(projectItem);
                    break;
                case "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}":
                    WriteLine("ParseProjectItem vsProjectItemKindPhysicalFolder");
                    ParseProjectItems(projectItem.ProjectItems);
                    break;
            }
        }

        private void ParseFile(ProjectItem projectItem)
        {
            if (projectItem.FileCodeModel == null)
            {
                WriteLine("ParseFile: " + projectItem.Name + " skipped because no code file");
                return;
            }
            if (!projectItem.Name.EndsWith(".cs"))
            {
                WriteLine("ParseFile: " + projectItem.Name + " skipped because no c# file");
                return;
            }
            WriteLine("ParseFile: " + projectItem.Name);


            var usings = new List<Namespace>();
            var currentFile = projectItem.FileNames[0];
            if (ProjectItems.ContainsKey(currentFile))
                return;

            ProjectItems.Add(currentFile, projectItem);
            foreach (var codeElement in projectItem.FileCodeModel.CodeElements.Cast<CodeElement2>())
            {
                if (codeElement is CodeImport)
                {
                    var @using = ParseUsing(codeElement);
                    WriteLine("Using " + @using.Name);
                    usings.Add(@using);
                }
                else
                {
                    ParseCodeElement(codeElement, usings, currentFile);
                }
            }
        }

        private static Namespace ParseUsing(CodeElement2 codeElement)
        {
            var codeImport = (CodeImport) codeElement;
            return new Namespace {Name = codeImport.Namespace};
        }

        private void ParseCodeElement(CodeElement2 codeElement, List<Namespace> usings, string currentFile)
        {
            switch (codeElement.Kind)
            {
                case vsCMElement.vsCMElementNamespace:
                    ParseNameSpace((CodeNamespace)codeElement, usings, currentFile);
                    break;
            }
        }

        private void ParseNameSpace(CodeNamespace codeNamespace, List<Namespace> usings, string currentFile)
        {
            var @namespace = new Namespace { Name = codeNamespace.Name };
            WriteLine("ParseNameSpace" + codeNamespace.Name);

            foreach (var element in codeNamespace.Members.Cast<CodeElement2>())
            {
                switch (element.Kind)
                {
                    case vsCMElement.vsCMElementInterface:
                        ParseInterface((CodeInterface2)element, usings, @namespace, currentFile);
                        break;
                    case vsCMElement.vsCMElementClass:
                        ParseClass((CodeClass2)element, usings, @namespace, currentFile);
                        break;
                }
            }
        }

        private void ParseClass(CodeClass2 codeClass, List<Namespace> usings, Namespace @namespace, string currentFile)
        {
            WriteLine("ParseClass" + " " + codeClass.Name);
            var @class = Classes.Find(c => c.Name == codeClass.Name) ??
                         new Class { Namespace = @namespace, Name = codeClass.Name, Usings = usings };
            @class.Files.Add(currentFile);
            foreach (CodeAttribute2 codeElement in codeClass.Attributes)
            {
                ParseAttribute(codeElement, @class, currentFile);
            }

            foreach (var element in codeClass.Members.Cast<CodeElement2>())
            {
                switch (element.Kind)
                {
                    case vsCMElement.vsCMElementFunction:
                        var function = ParseFunction((CodeFunction2)element, currentFile);
                        @class.Functions.Add(function);
                        break;
                    case vsCMElement.vsCMElementProperty:
                        var property = ParseProperty((CodeProperty)element, currentFile);
                        @class.Properties.Add(property);
                        break;
                    case vsCMElement.vsCMElementEvent:
                        var @event = ParseEvent((CodeEvent)element, currentFile);
                        @class.Events.Add(@event);
                        break;
                    case vsCMElement.vsCMElementVariable:
                        var field = ParseField((CodeVariable2) element, currentFile);
                        @class.Fields.Add(field);
                        break;
                }
            }
            Classes.Add(@class);
            
        }

        private Field ParseField(CodeVariable2 codeVariable, string currentFile)
        {
            WriteLine("ParseField" + " " + codeVariable.Name + " " + codeVariable.Type.AsString);

            var field = new Field {Name = codeVariable.Name, Type = codeVariable.Type.AsString, Access = codeVariable.Access.Convert(), FileName = currentFile};
            foreach (CodeAttribute2 attribute in codeVariable.Attributes)
            {
                ParseAttribute(attribute, field, currentFile);
            }
            return field;
        }

        private void ParseAttribute(CodeAttribute2 codeAttribute, AccessControlledElement element, string currentFile)
        {
            WriteLine("ParseAttribute" + " " + codeAttribute.Name);

            var attribute = new Attribute { Name = codeAttribute.Name, FileName = currentFile};

            foreach (CodeAttributeArgument codeArgument in codeAttribute.Arguments)
            {
                var value = codeArgument.Value;
                if (value.StartsWith("\"") && value.EndsWith("\""))
                {
                    value = value.Substring(1, value.Length - 2);
                }
                var argument = new Argument {Name = codeArgument.Name, Value = value};
                attribute.Arguments.Add(argument);
            }

            element.Attributes.Add(attribute);

        }

        private void ParseInterface(CodeInterface2 codeInterface, List<Namespace> usings, Namespace @namespace, string currentFile)
        {
            WriteLine("ParseInterface" + " " + codeInterface.Name);
            
            var @interface = new Interface { Namespace = @namespace, Name = codeInterface.Name, Usings = usings, Type = codeInterface.Name, FileName = currentFile};
            foreach (CodeAttribute2 codeElement in codeInterface.Attributes)
            {
                ParseAttribute(codeElement, @interface, currentFile);
            }

            foreach (var element in codeInterface.Members.Cast<CodeElement2>())
            {
                switch (element.Kind)
                {
                    case vsCMElement.vsCMElementFunction:
                        var function = ParseFunction((CodeFunction2)element, currentFile);
                        @interface.Functions.Add(function);
                        break;
                    case vsCMElement.vsCMElementProperty:
                        var property = ParseProperty((CodeProperty) element, currentFile);
                        @interface.Properties.Add(property); 
                        break;
                    case vsCMElement.vsCMElementEvent:
                        var @event = ParseEvent((CodeEvent) element, currentFile);
                        @interface.Events.Add(@event);
                        break;
                }
            }


            var interfaces = GetUnResolvedInterfaces(codeInterface);
            if (interfaces.Count > 0)
            {
                unresolvedInterfaces.Add(@interface, interfaces);
            }
            Interfaces.Add(@interface);
        }

        private  List<CodeInterface2> GetUnResolvedInterfaces(CodeInterface2 @interface)
        {
            var interfaces = new List<CodeInterface2>();

            if (@interface.Bases.Count <= 0)
                return interfaces;
            
            foreach (CodeInterface2 baseInterface in @interface.Bases)
            {
                interfaces.Add(baseInterface);
                interfaces.AddRange(GetUnResolvedInterfaces(baseInterface));
            }
            return interfaces;
        }

        private Event ParseEvent(CodeEvent codeEvent, string currentFile)
        {
            var @event = new Event {Name = codeEvent.Name, Type = codeEvent.Type.AsString, Access = codeEvent.Access.Convert(), FileName = currentFile};
            WriteLine("ParseEvent" + " " + codeEvent.Name + " " + codeEvent.Type);
            return @event;
        }

        private Property ParseProperty(CodeProperty codeProperty, string currentFile)
        {
            var property = new Property
                               {
                                   Name = codeProperty.Name, 
                                   Type = codeProperty.Type.AsString, 
                                   Access = codeProperty.Access.Convert(), 
                                   FileName = currentFile, 
                                   HasSetter = (codeProperty.Setter != null)
                               };
            WriteLine("ParseProperty" + " " + codeProperty.Name + " " + codeProperty.Type.AsString);
            foreach (CodeAttribute2 codeElement in codeProperty.Attributes)
            {
                ParseAttribute(codeElement, property, currentFile);
            }
            return property;
        }

        private Function ParseFunction(CodeFunction2 codeFunction, string currentFile)
        {
            var function = new Function {Name = codeFunction.Name, Type = codeFunction.Type.AsString, Access = codeFunction.Access.Convert(), FileName = currentFile};
            WriteLine("ParseFunction" + " " + function.Name + " " + function.Type);
            foreach (CodeAttribute2 codeElement in codeFunction.Attributes)
            {
                ParseAttribute(codeElement, function, currentFile);
            }


            foreach (var codeParameter in codeFunction.Parameters.Cast<CodeParameter2>())
            {
                var parmeter = ParseParameter(codeParameter);
                function.Parameters.Add(parmeter);
            }
            return function;
        }

        private Parameter ParseParameter(CodeParameter2 codeParameter)
        {
            var parameter = new Parameter {Name = codeParameter.Name, Type = codeParameter.Type.AsString, Modifier = codeParameter.ParameterKind.Convert()};
            WriteLine("ParseParameter" + " " + codeParameter.Name + " " + codeParameter.Type.AsString);
            return parameter;
        }
    }

}
