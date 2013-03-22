using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellOutNumber
{
    public static class Int32Extender
    {
        private static string[] _digits = new string[19] { "one","two","three","four","five","six","seven","eight","nine","ten",
                                                           "eleven","twelve","thirteen", "fourteen", "fifteen",
                                                           "sixteen", "seventeen", "eighteen", "nineteen" };

        private static string[] _tens = new string[8] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        public static string ToText(this int number)
        {
            if (number < 0)
                throw new NotSupportedException("Number Must be Positive");
            if (number == 0)
                return "zero";

            if (number < 20)
                return _digits[number - 1];

            return _tens[number / 10 - 2];
        }
    }
}
