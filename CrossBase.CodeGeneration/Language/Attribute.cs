using System;
using System.Collections.Generic;

namespace CrossBase.CodeGeneration.Language
{
    public class Attribute 
    {
        public string Name { get; set; }
        public List<Argument> Arguments { get; set; }
        public string FileName { get; set; }

        public Attribute()
        {
            Arguments = new List<Argument>();
        }

        public string GetArgument(string argumentName)
        {
            var argument = Arguments.Find(a => a.Name == argumentName);

            return argument == null ? string.Empty : argument.Value;
        }
    }

    public class Argument
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}