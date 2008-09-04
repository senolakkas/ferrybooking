using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace GreenTea.Utils
{
    public class StringUtils
    {
        public const string CommaSpace = ", ";

        private static string NullSafeToString(object obj)
        {
            return obj == null ? "(null)" : obj.ToString();
        }

        public static string ToString(object[] array)
        {
            int len = array.Length;

            // if there is no value in the array then return no string...
            if (len == 0)
            {
                return String.Empty;
            }

            StringBuilder buf = new StringBuilder(len * 12);
            for (int i = 0; i < len - 1; i++)
            {
                buf.Append(NullSafeToString(array[i])).Append(CommaSpace);
            }
            return buf.Append(NullSafeToString(array[len - 1])).ToString();
        }

        public static string Join(string separator, IEnumerable objects)
        {
            StringBuilder buf = new StringBuilder();
            bool first = true;

            foreach (object obj in objects)
            {
                if (!first)
                {
                    buf.Append(separator);
                }

                first = false;
                buf.Append(obj);
            }

            return buf.ToString();
        }

        public static string GetNullSafeString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            else
                return s;
        }

    }
}
