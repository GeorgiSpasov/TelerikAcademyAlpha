using System;
using System.Collections.Generic;

namespace OlympicGames.Utils
{
    public static class Validator
    {
        public static void ValidateIfNull(this object value, string msg = null)
        {
            if (msg == null)
            {
                msg = "Value cannot be null!";
            }

            if (value == null)
            {
                throw new ArgumentNullException(msg);
            }
        }

        public static void ValidateMinAndMaxNumber(this int value, int min, int max = int.MaxValue - 1, string msg = null)
        {
            if (msg == null)
            {
                msg = string.Format("Value must be between {0} and {1}!", min, max);
            }

            if (value < min || value > max)
            {
                throw new ArgumentException(msg);
            }
        }

        public static void ValidateMinAndMaxLength(this string value, int min, int max = int.MaxValue - 1, string msg = null)
        {
            if (msg == null)
            {
                msg = string.Format("Value must be between {0} and {1} characters long!", min, max);
            }

            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(msg);
            }
        }

        public static void ValidateParametersCount(this IList<string> value, int min, string msg = null)
        {
            if (msg == null)
            {
                msg = GlobalConstants.ParametersCountInvalid;
            }

            if (value.Count < min)
            {
                throw new ArgumentException(msg);
            }
        }

        public static void ValidateNumber(this object value, string msg = null)
        {
            try
            {
                int.Parse(value.ToString());
            }
            catch (Exception)
            {
                throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
            }
        }
    }
}
