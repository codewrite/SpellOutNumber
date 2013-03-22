using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberSpeller
{
    public static class Int32Extender
    {
        public static string ToText(this long number)
        {
            NumberString numStr = new NumberString(number);
            return numStr.Text;

        }
    }
}
