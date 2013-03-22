using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberSpeller
{
    public class NumberString
    {
        private static readonly string[] _digits = new string[] { "one","two","three","four","five","six","seven","eight","nine","ten",
                                                                  "eleven","twelve","thirteen", "fourteen", "fifteen",
                                                                  "sixteen", "seventeen", "eighteen", "nineteen" };

        private static readonly string[] _tens = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        private const string _aHundred = "hundred";

        private static readonly string[] _largeNames = new string[] { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };

        private StringBuilder numberText;

        public string Text { get { return numberText.ToString(); } }

        public NumberString(long number)
        {
            if (number < 0)
                throw new NotSupportedException("Number Must be Positive");

            numberText = new StringBuilder();

            if (number == 0)
                numberText.Append("zero");

            number = AppendLargeNumbers(number);
            number = AppendHundreds(number);
            AppendTo100(number);
        }

        private long AppendLargeNumbers(long number)
        {
            int i = _largeNames.Length - 1;
            long multiplier = 1;
            for (int j = 0; j <= i; j++)
                multiplier *= 1000;
            while (i >= 0)
            {
                if (number >= multiplier)
                {
                    long newNum = AppendHundreds(number / multiplier);
                    AppendTo100(newNum);
                    numberText.Append(" ");
                    numberText.Append(_largeNames[i]);
                    number %= multiplier;
                    if (number >= 100)
                        numberText.Append(", ");
                    else if (number > 0)
                        numberText.Append(" and ");
                }
                i--;
                multiplier /= 1000;
            }
            return number;
        }

        private long AppendHundreds(long number)
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

        private void AppendTo100(long number)
        {
            if (number > 0)
            {
                if (number >= 20)
                {
                    numberText.Append(_tens[number / 10 - 2]);
                    number %= 10;
                    if (number > 0)
                        numberText.Append(" ");
                }
                if (number > 0)
                    numberText.Append(_digits[number - 1]);
            }
        }
    }
}
