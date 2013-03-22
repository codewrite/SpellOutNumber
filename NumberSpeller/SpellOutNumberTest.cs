using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SpellOutNumber
{
    [TestFixture]
    class SpellOutNumberTest
    {
        [TestCase(1, "one")]
        [TestCase(2, "two")]
        [TestCase(3, "three")]
        [TestCase(9, "nine")]
        [TestCase(10, "ten")]
        [TestCase(11, "eleven")]
        [TestCase(15, "fifteen")]
        [TestCase(19, "nineteen")]
        public void SimpleNumberTest(int number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(20, "twenty")]
        [TestCase(30, "thirty")]
        [TestCase(90, "ninety")]
        public void TensNumberTest(int number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(24, "twenty four")]
        [TestCase(37, "thirty seven")]
        [TestCase(99, "ninety nine")]
        public void SimpleCombinationTest(int number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [TestCase(100, "one hundred")]
        [TestCase(200, "two hundred")]
        [TestCase(900, "nine hundred")]
        public void HundredsTest(int number, string numberText)
        {
            Assert.AreEqual(number.ToText(), numberText);
        }

        [Test]
        public void ZeroTest()
        {
            int zero = 0;
            Assert.AreEqual(zero.ToText(), "zero");
        }

        [TestCase(-1)]
        [TestCase(-15)]
        [ExpectedException(typeof(NotSupportedException))]
        public void NegativeTest(int number)
        {
            number.ToText();
        }


    }
}
