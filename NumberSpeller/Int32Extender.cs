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

        private static string _aHundred = "hundred";

        public static string ToText(this int number)
        {
            if (number < 0)
                throw new NotSupportedException("Number Must be Positive");
            if (number == 0)
                return "zero";
            if (number < 20)
                return _digits[number - 1];

            StringBuilder numberText;
            int remainder;

            if (number < 100)
            {
                if (number % 10 == 0)
                    return _tens[number / 10 - 2];
                else
                {
                    numberText = new StringBuilder(_tens[number / 10 - 2] + " ");
                    remainder = number % 10;
                    if (remainder > 0)
                        numberText.Append(_digits[remainder - 1]);
                    return numberText.ToString();
                }
            }
            numberText = new StringBuilder(_digits[number / 100 - 1] + " ");
            numberText.Append(_aHundred);
            return numberText.ToString();
        }
    }
}
