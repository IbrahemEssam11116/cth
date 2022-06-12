using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SStorm.CTH.BL.Helpers
{
    public static class TypeExtentions
    {
        public static void ForEach<T>(this EntityCollection<T> enumeration, Action<T> action) where T : EntityBase2, IEntity2
        {

            foreach (T item in enumeration)
            {
                action(item);
            }
        }
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {

            foreach (T item in enumeration)
            {
                action(item);
            }
        }
        public static string IFEmpty(this string input, string ValueIfNull)
        {
            return string.IsNullOrWhiteSpace(input) ? ValueIfNull : input;
        }

        public static string Separate(this string ConcatenatedString)
        {
            if (string.IsNullOrWhiteSpace(ConcatenatedString))
                return ConcatenatedString;
            string regx = @"((?<=[a-z])[A-Z]|[A-Z](?=[a-z]))";
            return System.Text.RegularExpressions.Regex.Replace(ConcatenatedString, regx, " $1").Trim();

        }

        public static bool IsEqualTo(this string str, string value)
        {
            return IsEqualTo(str, value, true);
        }

        public static bool IsEqualTo(this string str, string value, bool ignoreCase)
        {
            return (string.Compare(str, value, ignoreCase) == 0);
        }


        public static int IfZero(this int value, int toReturn)
        {
            return value == 0 ? toReturn : value;
        }
        public static void Remove<T>(this EntityCollection<T> enumeration, Func<T, bool> predicate) where T : EntityBase2, IEntity2
        {
            List<T> toRemove = new List<T>();
            foreach (T item in enumeration)
            {
                if (predicate(item))
                    toRemove.Add(item);
            }
            toRemove.ForEach(x => enumeration.Remove(x));
        }


        public static string TrimSafe(this string value)
        {
            if (value == null)
                return value;

            return value.Trim();
        }

        /// <summary>
		/// Replaces pascal casing with spaces. For example "CandidateId" would become "Candidate Id".
		/// </summary>
        /// <remarks>
        /// Strings that already contain spaces are ignored.
        /// </remarks>
        public static string ToStringPascalCase(this string value)
        {
            var sb = new StringBuilder();

            char[] ca = value.ToCharArray();
            sb.Append(ca[0]);
            for (int i = 1; i < ca.Length - 1; i++)
            {
                char c = ca[i];
                if (char.IsUpper(c) && (char.IsLower(ca[i + 1]) || char.IsLower(ca[i - 1])))
                    sb.Append(" ");

                sb.Append(c);
            }

            if (ca.Length > 1)
                sb.Append(ca[ca.Length - 1]);

            return sb.ToString();
        }

        public static IPrefetchPathElement2 Add(this IPrefetchPath2 SubPath, IPrefetchPathElement2 elementToAdd, bool IncludeFields, params IEntityField2[] fields)
        {
            return SubPath.Add(elementToAdd, null, IncludeFields, fields);
        }

        public static IPrefetchPathElement2 Add(this IPrefetchPath2 SubPath, IPrefetchPathElement2 elementToAdd, PredicateExpression additionalFilter, bool IncludeFields, params IEntityField2[] fields)
        {
            var _excludeIncludeFieldsList = new ExcludeIncludeFieldsList(!IncludeFields);
            foreach (var item in fields)
            {
                _excludeIncludeFieldsList.Add(item);
            }
            return SubPath.Add(elementToAdd, 0, additionalFilter, null, null, null, _excludeIncludeFieldsList);
        }
    }
}
