using System.Collections.Generic;
using System.Linq;
using CrossBase.CodeGeneration.Language;

namespace CrossBase.CodeGeneration.Language
{
    public class Class : ClassElement
    {
        public List<Field> Fields { get; set; }
        public List<string> Files { get; set; }

        public Class()
        {
            Fields = new List<Field>();
            Files = new List<string>();
        }

        public string FileWithShortestName()
        {
            var l = int.MaxValue;
            var r = string.Empty;
// ReSharper disable AccessToModifiedClosure
            foreach (var file in Files.Where(file => file.Length < l))
// ReSharper restore AccessToModifiedClosure
            {
                l = file.Length;
                r = file;
            }
            return r;
        }
    }
}