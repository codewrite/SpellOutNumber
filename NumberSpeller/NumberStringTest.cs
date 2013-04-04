using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NumberSpeller
{
    [TestFixture]
    class NumberStringTest
    {
        [TestCase(1, "one")]
        [TestCase(2, "two")]
        [TestCase(3, "three")]
        [TestCase(9, "nine")]
        [TestCase(10, "ten")]
        [TestCase(11, "eleven")]
        [TestCase(15, "fifteen")]
        [TestCase(19, "nineteen")]
        public void SpellNumbersUnder20Test(long number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(20, "twenty")]
        [TestCase(30, "thirty")]
        [TestCase(90, "ninety")]
        public void SpellMutiplesOfTenTest(long number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(24, "twenty four")]
        [TestCase(37, "thirty seven")]
        [TestCase(99, "ninety nine")]
        public void SpellNumbersUnder100Test(long number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(100, "one hundred")]
        [TestCase(200, "two hundred")]
        [TestCase(900, "nine hundred")]
        public void SpellMultiplesOf100Test(long number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(310, "three hundred and ten")]
        [TestCase(2001, "two thousand and one")]
        [TestCase(3012, "three thousand and twelve")]
        [TestCase(3599, "three thousand, five hundred and ninety nine")]
        [TestCase(1501, "one thousand, five hundred and one")]
        [TestCase(12609, "twelve thousand, six hundred and nine")]
        [TestCase(512607, "five hundred and twelve thousand, six hundred and seven")]
        [TestCase(900001, "nine hundred thousand and one")]
        [TestCase(999999, "nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void SpellMultiplesOf1000Test(long number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(27000003, "twenty seven million and three")]
        [TestCase(13001005, "thirteen million, one thousand and five")]
        [TestCase(43112603, "forty three million, one hundred and twelve thousand, six hundred and three")]
        [TestCase(999999999, "nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void SpellNumbersInMillionsTest(long number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(123043112603, "one hundred and twenty three billion, forty three million, one hundred and twelve thousand, six hundred and three")]
        public void SpellNumbersInBilionsTest(long number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase((long)9E18, "nine quintillion")]
        [TestCase((long)(4E17 + 17E6), "four hundred quadrillion, seventeen million")]
        [TestCase(long.MaxValue, "nine quintillion, two hundred and twenty three quadrillion, three hundred and seventy two trillion, thirty six" +
                               " billion, eight hundred and fifty four million, seven hundred and seventy five thousand, eight hundred and seven")]
        public void SpellReallyBigNumbersTest(long number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [Test]
        public void SpellZeroTest()
        {
            long zero = 0;
            Assert.AreEqual(zero.ToText(), "zero");
        }

        [TestCase(-1)]
        [TestCase(-15)]
        [ExpectedException(typeof(NotSupportedException))]
        public void NegativeNumbersThrowExceptionTest(long number)
        {
            number.ToText();
        }


    }
}
