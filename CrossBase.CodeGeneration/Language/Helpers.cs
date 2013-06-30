using System;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using EnvDTE80;

namespace CrossBase.CodeGeneration.Language
{
    public enum ChangeCase
    {
        ToLower,
        ToUpper
    }

    public static class Helpers
    {
        public static string GetDefaultPropertyName(this Interface @interface)
        {
            return @interface.Name.Substring(1);
        }

        public static string GetDefaultPrivateFieldName(this Interface @interface)
        {
            return @interface.GetDefaultPropertyName().ChangeFirstChar(ChangeCase.ToLower);
        }

        public static string GetDefaultPrivateFieldName(this Property property)
        {
            return property.Name.ChangeFirstChar(ChangeCase.ToLower);
        }

        public static bool StartsWithCapital(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
         
            var first = s[0];
            return first >= 'a' && first <= 'z';
        }

        public static string ChangeFirstChar(this string s, ChangeCase changeCase)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var first = string.Empty + s[0];
            switch (changeCase)
            {
                case ChangeCase.ToLower:
                    first = first.ToLower();
                    break;
                case ChangeCase.ToUpper:
                    first = first.ToUpper();
                    break;
            }

            return s.Length == 1 ? first : first + s.Substring(1);
        }


        public static string GetDefaultPublicPropertyName(this Field field)
        {
            return field.Name.ChangeFirstChar(ChangeCase.ToUpper);
        }

        public static List<string> ToList(this List<Namespace> namespaces)
        {
            return namespaces.Select(nameSpace => nameSpace.Name).ToList();
        }

        public static Modifier Convert(this vsCMParameterKind kind)
        {
            var modifier = Modifier.None;
            switch (kind)
            {
                case vsCMParameterKind.vsCMParameterKindIn:
                    modifier = Modifier.In;
                    break;
                case vsCMParameterKind.vsCMParameterKindRef:
                    modifier = Modifier.Ref;
                    break;
                case vsCMParameterKind.vsCMParameterKindOut:
                    modifier = Modifier.Out;
                    break;
                case vsCMParameterKind.vsCMParameterKindOptional:
                    modifier = Modifier.Optional;
                    break;
                case vsCMParameterKind.vsCMParameterKindParamArray:
                    modifier = Modifier.Array;
                    break;
                case vsCMParameterKind.vsCMParameterKindNone:
                default:
                    break;
            }

            return modifier;
        }

        public static Access Convert(this vsCMAccess vsCmAccess)
        {
            var access = Access.Public;
            switch (vsCmAccess)
            {
                case vsCMAccess.vsCMAccessPublic:
                    access = Access.Public;
                    break;
                case vsCMAccess.vsCMAccessPrivate:
                    access = Access.Private;
                    break;
                case vsCMAccess.vsCMAccessProject:
                    access = Access.Internal;
                    break;
                case vsCMAccess.vsCMAccessProtected:
                    access = Access.Protected;
                    break;
                case vsCMAccess.vsCMAccessDefault:
                    break;
                case vsCMAccess.vsCMAccessAssemblyOrFamily:
                    access = Access.Internal;
                    break;
                case vsCMAccess.vsCMAccessWithEvents:
                    access = Access.Public;
                    break;
                case vsCMAccess.vsCMAccessProjectOrProtected:
                    access = Access.Internal;
                    break;
                default:
                    break;
            }
            return access;
        }
    }
}