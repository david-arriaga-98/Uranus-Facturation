using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoPuntoNet.Utils
{
    public static class Validations
    {
        public static bool IsEmpty(this string text)
        {
            return text.Equals("");
        }

        public static bool IsEmpty<T>(this IList<T> values)
        {
            return values.Count.Equals(0);
        }

        public static bool IsInteger(this string value)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(value);
        }

        public static bool IsEmail(this string value)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(value);
        }

        public static bool IsDouble(this string value)
        {
            try
            {
                Convert.ToDouble(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
