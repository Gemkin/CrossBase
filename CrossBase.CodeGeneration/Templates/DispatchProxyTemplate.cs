// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 11.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CrossBase.CodeGeneration.Templates
{
    using CodeGeneration.Attributes;
    using System.Collections.Generic;
    using CodeGeneration.Language;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public partial class DispatchProxyTemplate : CodeGeneration.Templates.TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 6 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

    public string ClassName;
	public string ProxyName;
	public string InterfaceName;
	public string ProxyNamespace;
	public List<string> CustomDefaultNamespaces;

	public override void Render()
	{
		debugOutput = string.Empty;
		var classes = Parser.GetAllClassesThatHaveAnAttribute("DispatchProxy");

		foreach (var @class in classes)
		{
			foreach(var attribute in @class.Attributes)
			{
				if (attribute.Name != "DispatchProxy")
					continue;
						
				ProxyName = @class.Name;
				ProxyNamespace = @class.Namespace.Name;
				InterfaceName = attribute.GetArgument("InterfaceName");
				ClassName = attribute.GetArgument("ClassName");
				
				var fileName = attribute.FileName;
				var projectItem = Parser.GetProjectItem(fileName);
				var outputFileName = fileName.Replace(".cs", "." + InterfaceName + ".DispatchProxy.g.cs");

				if (string.IsNullOrEmpty(InterfaceName))
				{
					debugOutput += string.Format("InterfaceName not set on DispatchProxy attribute on class {0}\r\n", @class.Name);		
					continue;
				}

				var @interface = Parser.Interfaces.Find(f=> f.Name == InterfaceName);
				if (@interface == null)
				{
					debugOutput += string.Format("Interface {1} not found DispatchProxy attribute on class {0}\r\n", @class.Name, InterfaceName);		
					continue;
				}

			    var useDefaultRule = false;
				if (string.IsNullOrEmpty(ClassName))
				{
					debugOutput += string.Format("ClassName to proxy not set on DispatchProxy attribute on class {0}, using default name derived from interface name\r\n", @class.Name);
				    useDefaultRule = true;
				}


				var fieldName =  useDefaultRule ? @interface.GetDefaultPrivateFieldName() : ClassName.ChangeFirstChar(ChangeCase.ToLower);
				var propertyName = useDefaultRule? @interface.GetDefaultPropertyName() : ClassName;


			    var containsNotifyPropertyChanged = @interface.Events.Exists((s) => s.Name == "PropertyChanged");

				GenerateHeader();
			    var usings = new List<string>
			        {
			            "System",
			            "CrossBase.Common",
			            "CrossBase.Reflection",
			            "CrossBase.Common.Dispatch",
			            @class.Namespace.Name
			        };
				if (containsNotifyPropertyChanged)
					usings.Add("System.ComponentModel");
				GenerateUsings(@class, usings);

        
        #line default
        #line hidden
        
        #line 73 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("using ");

        
        #line default
        #line hidden
        
        #line 74 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(@interface.Namespace.Name));

        
        #line default
        #line hidden
        
        #line 74 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n\r\nnamespace ");

        
        #line default
        #line hidden
        
        #line 76 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ProxyNamespace));

        
        #line default
        #line hidden
        
        #line 76 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\r\n{\r\n\tpublic interface I");

        
        #line default
        #line hidden
        
        #line 78 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ProxyName));

        
        #line default
        #line hidden
        
        #line 78 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Ex\r\n\t{\r\n");

        
        #line default
        #line hidden
        
        #line 80 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

		foreach (var evnt in @interface.Events)
		{
        
        #line default
        #line hidden
        
        #line 82 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\tevent ");

        
        #line default
        #line hidden
        
        #line 83 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Type));

        
        #line default
        #line hidden
        
        #line 83 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" ");

        
        #line default
        #line hidden
        
        #line 83 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 83 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n");

        
        #line default
        #line hidden
        
        #line 84 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

		}
		foreach (var function in @interface.Functions)
		{
        
        #line default
        #line hidden
        
        #line 87 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\t");

        
        #line default
        #line hidden
        
        #line 88 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.InterfaceSignature("")));

        
        #line default
        #line hidden
        
        #line 88 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n\t\tevent EventHandler<EventArgs> ");

        
        #line default
        #line hidden
        
        #line 89 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 89 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Started;\r\n\t\tevent EventHandler<EventArgs> ");

        
        #line default
        #line hidden
        
        #line 90 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 90 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Finished;\r\n");

        
        #line default
        #line hidden
        
        #line 91 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
 
		}
        
        #line default
        #line hidden
        
        #line 92 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t}\r\n\t\r\n\tpublic partial class ");

        
        #line default
        #line hidden
        
        #line 95 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ProxyName));

        
        #line default
        #line hidden
        
        #line 95 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(": I");

        
        #line default
        #line hidden
        
        #line 95 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(ProxyName));

        
        #line default
        #line hidden
        
        #line 95 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Ex");

        
        #line default
        #line hidden
        
        #line 95 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
 if (containsNotifyPropertyChanged){
        
        #line default
        #line hidden
        
        #line 95 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(", INotifyPropertyChanged");

        
        #line default
        #line hidden
        
        #line 95 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
}
        
        #line default
        #line hidden
        
        #line 95 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\r\n\t{\r\n\t\tpublic IDispatcher UpDispatcher { get; set; }\r\n        public IDispatcher" +
        " DownDispatcher { get; set; }\r\n        \r\n");

        
        #line default
        #line hidden
        
        #line 101 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
			foreach (var evnt in @interface.Events)
				{
        
        #line default
        #line hidden
        
        #line 102 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\tpublic event ");

        
        #line default
        #line hidden
        
        #line 103 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Type));

        
        #line default
        #line hidden
        
        #line 103 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" ");

        
        #line default
        #line hidden
        
        #line 103 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 103 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n");

        
        #line default
        #line hidden
        
        #line 104 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				}

        
        #line default
        #line hidden
        
        #line 107 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				if (containsNotifyPropertyChanged)
				{
				    foreach (var prop in @interface.Properties)
				    { 
        
        #line default
        #line hidden
        
        #line 111 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\tprivate ");

        
        #line default
        #line hidden
        
        #line 112 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(prop.Type));

        
        #line default
        #line hidden
        
        #line 112 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" ");

        
        #line default
        #line hidden
        
        #line 112 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(prop.GetDefaultPrivateFieldName()));

        
        #line default
        #line hidden
        
        #line 112 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n\t\tpublic ");

        
        #line default
        #line hidden
        
        #line 113 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(prop.Type));

        
        #line default
        #line hidden
        
        #line 113 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" ");

        
        #line default
        #line hidden
        
        #line 113 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(prop.Name));

        
        #line default
        #line hidden
        
        #line 113 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" \r\n\t\t{\r\n\t\t\tget\r\n\t\t\t{\r\n\t\t\t\treturn ");

        
        #line default
        #line hidden
        
        #line 117 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(prop.GetDefaultPrivateFieldName()));

        
        #line default
        #line hidden
        
        #line 117 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n\t\t\t}\r\n\t\t\tset\r\n\t\t\t{\r\n\t\t\t\tvar clone = value.DeepClone();\r\n\t\t\t\tDownDispatcher.Beg" +
        "inInvoke(() => \r\n\t\t\t\t{\r\n\t\t\t\t\tif (clone == ");

        
        #line default
        #line hidden
        
        #line 124 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 124 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 124 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(prop.Name));

        
        #line default
        #line hidden
        
        #line 124 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(")\r\n\t\t\t\t\t\treturn;\r\n\t\t\t\t\t");

        
        #line default
        #line hidden
        
        #line 126 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 126 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 126 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(prop.Name));

        
        #line default
        #line hidden
        
        #line 126 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" = value; \r\n\t\t\t\t});\r\n\r\n\t\t\t}\r\n\t\t}\r\n");

        
        #line default
        #line hidden
        
        #line 131 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				    }
				}
				foreach (var function in @interface.Functions)
				{
        
        #line default
        #line hidden
        
        #line 135 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\tpublic event EventHandler<EventArgs> ");

        
        #line default
        #line hidden
        
        #line 136 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 136 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Started;\r\n\t\tpublic event EventHandler<EventArgs> ");

        
        #line default
        #line hidden
        
        #line 137 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 137 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Finished;\r\n\t\t\r\n\t\tprivate void Invoke");

        
        #line default
        #line hidden
        
        #line 139 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 139 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Started(EventArgs e)\r\n\t    {\r\n\t       \tvar handler = ");

        
        #line default
        #line hidden
        
        #line 141 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 141 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Started;\r\n\t       \tif (handler != null) handler(this, e);\r\n\t    }\r\n\t\t\t\r\n\t\tprivate" +
        " void Invoke");

        
        #line default
        #line hidden
        
        #line 145 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 145 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Finished(EventArgs e)\r\n\t    {\r\n\t       \tvar handler = ");

        
        #line default
        #line hidden
        
        #line 147 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 147 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Finished;\r\n\t       \tif (handler != null) handler(this, e);\r\n\t    }\t\r\n\t\t");

        
        #line default
        #line hidden
        
        #line 150 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				}
				
        
        #line default
        #line hidden
        
        #line 152 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\tprivate  ");

        
        #line default
        #line hidden
        
        #line 153 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(@interface.Name));

        
        #line default
        #line hidden
        
        #line 153 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" ");

        
        #line default
        #line hidden
        
        #line 153 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 153 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n\t\t\t\r\n\t\tpublic ");

        
        #line default
        #line hidden
        
        #line 155 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(@interface.Name));

        
        #line default
        #line hidden
        
        #line 155 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" ");

        
        #line default
        #line hidden
        
        #line 155 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(propertyName));

        
        #line default
        #line hidden
        
        #line 155 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\r\n\t\t{\r\n\t\t\tget\r\n\t\t\t{\r\n\t\t\t\treturn ");

        
        #line default
        #line hidden
        
        #line 159 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 159 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n\t\t\t}\r\n\t\t\tset\r\n\t\t\t{\t\t\t\r\n\t\t\t\tif (");

        
        #line default
        #line hidden
        
        #line 163 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 163 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" != null) \r\n\t\t\t\t\tUnsubscribeTo");

        
        #line default
        #line hidden
        
        #line 164 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(propertyName));

        
        #line default
        #line hidden
        
        #line 164 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("();\r\n\r\n\t\t\t\t");

        
        #line default
        #line hidden
        
        #line 166 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 166 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" = value;\r\n\t\t\t\tSubscribeTo");

        
        #line default
        #line hidden
        
        #line 167 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(propertyName));

        
        #line default
        #line hidden
        
        #line 167 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("();\r\n\t\t\t}\r\n\t\t}\r\n");

        
        #line default
        #line hidden
        
        #line 170 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				foreach (var evnt in @interface.Events)
				{
					if (evnt.Name == "PropertyChanged")
					{

        
        #line default
        #line hidden
        
        #line 175 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\tprivate void On");

        
        #line default
        #line hidden
        
        #line 176 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 176 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Handler(object sender, PropertyChangedEventArgs e)\r\n\t\t{\r\n\t\t\tswitch (e.PropertyNam" +
        "e)\r\n\t\t\t{\r\n");

        
        #line default
        #line hidden
        
        #line 180 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

						foreach (var property in @interface.Properties)
						{

        
        #line default
        #line hidden
        
        #line 183 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\t\t\tcase \"");

        
        #line default
        #line hidden
        
        #line 184 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));

        
        #line default
        #line hidden
        
        #line 184 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\":\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tvar propClone = ");

        
        #line default
        #line hidden
        
        #line 186 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 186 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 186 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));

        
        #line default
        #line hidden
        
        #line 186 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(".DeepClone();\r\n\t\t\t\t\t\tSystemServices.Dispatchers[DispatcherId.Ui].BeginInvoke(() =" +
        ">\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t");

        
        #line default
        #line hidden
        
        #line 189 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.GetDefaultPrivateFieldName()));

        
        #line default
        #line hidden
        
        #line 189 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" = propClone;\r\n\t\t\t\t\t\t\t\tvar handler = PropertyChanged;\r\n\t\t\t\t\t\t\t\tif (handler != nul" +
        "l) handler(this, new PropertyChangedEventArgs(e.PropertyName));\r\n\t\t\t\t\t\t\t});\r\n\r\n\t" +
        "\t\t\t\t\tbreak;\r\n\t\t\t\t\t}\r\n");

        
        #line default
        #line hidden
        
        #line 196 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

						}

        
        #line default
        #line hidden
        
        #line 198 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\t\t\t\t\r\n\t\t\t}\r\n\t\t}\r\n\r\n");

        
        #line default
        #line hidden
        
        #line 203 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

						
					}
					else
					{

        
        #line default
        #line hidden
        
        #line 208 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\tprivate void On");

        
        #line default
        #line hidden
        
        #line 209 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 209 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Handler(object sender, ");

        
        #line default
        #line hidden
        
        #line 209 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.GenericEventHandlerType));

        
        #line default
        #line hidden
        
        #line 209 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" e)\r\n\t\t{\r\n\t\t\tvar clone = e.DeepClone();\r\n\t\t\tUpDispatcher.BeginInvoke(() =>\r\n\t\t\t\t{" +
        "\r\n\t\t\t\t\tvar handler = ");

        
        #line default
        #line hidden
        
        #line 214 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 214 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n\t\t\t\t\tif (handler != null) handler(this, clone);\r\n\t\t\t\t});\r\n\t\t}\r\n");

        
        #line default
        #line hidden
        
        #line 218 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

					}
				}

        
        #line default
        #line hidden
        
        #line 221 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\tpublic void UnsubscribeTo");

        
        #line default
        #line hidden
        
        #line 222 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(propertyName));

        
        #line default
        #line hidden
        
        #line 222 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("()\r\n\t\t{\r\n\t\t\tif (");

        
        #line default
        #line hidden
        
        #line 224 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 224 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" == null)\r\n\t\t\t\treturn;\r\n");

        
        #line default
        #line hidden
        
        #line 226 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				foreach (var evnt in @interface.Events)
				{

        
        #line default
        #line hidden
        
        #line 229 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\t\t");

        
        #line default
        #line hidden
        
        #line 230 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 230 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 230 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 230 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" -= On");

        
        #line default
        #line hidden
        
        #line 230 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 230 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Handler;\r\n");

        
        #line default
        #line hidden
        
        #line 231 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				}
		
        
        #line default
        #line hidden
        
        #line 233 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\t}\t\t\r\n\r\n\t\tprivate void SubscribeTo");

        
        #line default
        #line hidden
        
        #line 236 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(propertyName));

        
        #line default
        #line hidden
        
        #line 236 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("()\r\n\t\t{\r\n");

        
        #line default
        #line hidden
        
        #line 238 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				foreach (var evnt in @interface.Events)
				{

        
        #line default
        #line hidden
        
        #line 241 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\t\t");

        
        #line default
        #line hidden
        
        #line 242 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 242 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 242 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 242 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(" += On");

        
        #line default
        #line hidden
        
        #line 242 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(evnt.Name));

        
        #line default
        #line hidden
        
        #line 242 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Handler;\r\n");

        
        #line default
        #line hidden
        
        #line 243 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				}
		
        
        #line default
        #line hidden
        
        #line 245 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\t}\r\n\r\n");

        
        #line default
        #line hidden
        
        #line 248 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				foreach (var function in @interface.Functions)
				{
        
        #line default
        #line hidden
        
        #line 250 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t\t");

        
        #line default
        #line hidden
        
        #line 251 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Signature("")));

        
        #line default
        #line hidden
        
        #line 251 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\r\n\t\t{\r\n\t\t\tDownDispatcher.BeginInvoke(() => \r\n\t\t\t\t{\r\n\t\t\t\t\tUpDispatcher.BeginInvoke" +
        "(() => Invoke");

        
        #line default
        #line hidden
        
        #line 255 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 255 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Started(EventArgs.Empty));\r\n\t\t\t\t\ttry\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\t");

        
        #line default
        #line hidden
        
        #line 258 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 258 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 258 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.CallSignature("")));

        
        #line default
        #line hidden
        
        #line 258 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(";\r\n\t\t\t\t\t}\r\n\t\t\t\t\tfinally\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tUpDispatcher.BeginInvoke(() => Invoke");

        
        #line default
        #line hidden
        
        #line 262 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(function.Name));

        
        #line default
        #line hidden
        
        #line 262 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("Finished(EventArgs.Empty));\r\n\t\t\t\t\t}\r\n\t\t\t\t});\r\n\t\t}\r\n");

        
        #line default
        #line hidden
        
        #line 266 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
				}
        
        #line default
        #line hidden
        
        #line 266 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"
this.Write("\t}\r\n}\r\n\r\n");

        
        #line default
        #line hidden
        
        #line 270 "C:\projects\CrossBase\CrossBase.CodeGeneration\Templates\DispatchProxyTemplate.tt"

				GenerateFooter();
				debugOutput += string.Format("Generated {0}\r\n", outputFileName);
				Delete(projectItem, outputFileName);
				Save(projectItem, outputFileName);
			}
		}
		base.Render();
	}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
