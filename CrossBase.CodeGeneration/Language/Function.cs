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

        public string CallSignature(string prefix = "", string postFix = "")
        {
            var param = string.Empty;

            for (int i = 0; i < Parameters.Count; i++)
            {
                param += Parameters[i].CallSignature();
                if (i != Parameters.Count - 1)
                    param += ", ";
            }

            return string.Format("{0}{1}{2}({3})", prefix, Name, postFix, param);
        }


        public string Signature(string prefix = "", string postFix = "")
        {
            var param = string.Empty;

            for (int i = 0; i < Parameters.Count; i++)
            {
                param += Parameters[i].ToString();
                if (i != Parameters.Count -1)
                    param += ", ";
            }

            return string.Format("{0} {1} {2}{3}{4}({5})", Access.ToString().ToLower(), Type, prefix, Name, postFix, param);
        }

        public string InterfaceSignature(string prefix = "", string postFix = "")
        {
            var param = string.Empty;

            for (int i = 0; i < Parameters.Count; i++)
            {
                param += Parameters[i].ToString();
                if (i != Parameters.Count - 1)
                    param += ", ";
            }

            return string.Format("{0} {1}{2}{3}({4})", Type, prefix, Name, postFix, param);
        }

    }
}