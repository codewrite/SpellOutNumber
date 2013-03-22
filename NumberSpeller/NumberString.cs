using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberSpeller
{
    public class NumberString
    {
        private static string[] _digits = new string[19] { "one","two","three","four","five","six","seven","eight","nine","ten",
                                                           "eleven","twelve","thirteen", "fourteen", "fifteen",
                                                           "sixteen", "seventeen", "eighteen", "nineteen" };

        private static string[] _tens = new string[9] { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        private const string _aHundred = "hundred";
        private const string _aThousand = "thousand";

        private StringBuilder numberText;

        public string Text { get { return numberText.ToString(); } }

        public NumberString(int number)
        {
            if (number < 0)
                throw new NotSupportedException("Number Must be Positive");

            numberText = new StringBuilder();

            if (number == 0)
                numberText.Append("zero");

            number = AppendThousands(number);

            number = AppendHundreds(number);

            number = AppendTo20(number);
        }

        private int AppendTo20(int number)
        {
            if (number > 0)
            {
                if (number >= 20)
                {
                    numberText.Append(_tens[number / 10 - 1]);
                    number %= 10;
                    if (number > 0)
                        numberText.Append(" ");
                }
                if (number > 0)
                    numberText.Append(_digits[number - 1]);
            }
            return number;
        }

        private int AppendHundreds(int number)
        {
            if (number >= 100)
            {
                numberText.Append(_digits[number / 100 - 1] + " ");
                numberText.Append(_aHundred);
                number %= 100;
                if (number > 0)
                    numberText.Append(" and ");
            }

            return number;
        }

        private int AppendThousands(int number)
        {
            if (number >= 1000)
            {
                numberText.Append(_digits[number / 1000 - 1] + " ");
                numberText.Append(_aThousand);
                number %= 1000;
                if (number >= 100)
                    numberText.Append(", ");
                else if (number > 0)
                    numberText.Append(" and ");
            }

            return number;
        }
    }
}
