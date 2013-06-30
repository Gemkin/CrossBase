using System;
using System.Collections.Generic;

namespace CrossBase.CodeGeneration.Language
{
    public class Function: AccessControlledElement
    {
        public List<Parameter> Parameters { get; set; }

        public string FileName { get; set; }

        public Function()
        {
            Parameters = new List<Parameter>();
        }

        public override string ToString()
        {
            return Signature(string.Empty);
        }

        public string CallSignature(string prefix)
        {
            var param = string.Empty;

            for (int i = 0; i < Parameters.Count; i++)
            {
                param += Parameters[i].CallSignature();
                if (i != Parameters.Count - 1)
                    param += ", ";
            }

            return string.Format("{0}{1}({2})", prefix, Name, param);
        }


        public string Signature(string prefix)
        {
            var param = string.Empty;

            for (int i = 0; i < Parameters.Count; i++)
            {
                param += Parameters[i].ToString();
                if (i != Parameters.Count -1)
                    param += ", ";
            }

            return string.Format("{0} {1} {2}{3}({4})", Access.ToString().ToLower(), Type, prefix, Name, param);
        }

        public string InterfaceSignature(string prefix)
        {
            var param = string.Empty;

            for (int i = 0; i < Parameters.Count; i++)
            {
                param += Parameters[i].ToString();
                if (i != Parameters.Count - 1)
                    param += ", ";
            }

            return string.Format("{0} {1}{2}({3})", Type, prefix, Name, param);
        }

    }
}