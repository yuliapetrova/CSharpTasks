using System;
using NUnit.Framework;
using CSharpCalculator;
using NUnit.Framework.Constraints;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        private Calculator Calc;

        [SetUp]
        public void Setup()
        {
            Calc = new Calculator();
        }

        // Abs
        [Test]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(-7.176, ExpectedResult = 7.176)]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("-1", ExpectedResult = 1)]
        [TestCase("-1.758", ExpectedResult = 1)]

        public object AbsTest(object x)
        {
            return Calc.Abs(x);
        }

        // Add
        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(-5, 5, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(-10, -5, -15)]
        [TestCase(2.25, -3.25, -1)]
        [TestCase("2", "3", 5)]
        [TestCase("2.5", "3.5", 6)]
        [TestCase("-2", "3", 1)]

        public void AddTest(object a, object b, double expected)
        {
            Assert.AreEqual(expected, Calc.Add(a, b));
        }

        // Cos
        [Test]
        [TestCase(90, ExpectedResult = 0)]
        [TestCase(-90, ExpectedResult = 0)]
        [TestCase(-120, ExpectedResult = -0.5)]
        [TestCase(0, ExpectedResult = 1)]
        [TestCase(Math.PI/2, ExpectedResult = 0)]
        [TestCase(Math.PI, ExpectedResult = -1)]
        [TestCase("90", ExpectedResult = 0)]

        public object CosTest(object x)
        {
            return Calc.Cos(x);
        }
        
        //Divide
        [Test]
        [TestCase(10, 10, 1)]
        [TestCase(10, 2, 5)]
        [TestCase(5, -5, -1)]
        [TestCase("15", "3", 5)]
        public void DivideTest(double a, double b, double expected)
        {
            Assert.AreEqual(expected, Calc.Divide(a, b));
        }
        //Divide by zero
        [TestCase(1,0)]
        public void DivideByZeroTest(double a, double b)
        {
            Assert.Throws<FormatException>(() => Calc.Divide(a,b));
        }

        //isNegative
        [Test]
        [TestCase(-10, ExpectedResult = true)]
        [TestCase(-10.454, ExpectedResult = true)]
        [TestCase(-0, ExpectedResult = false)]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(10.454, ExpectedResult = false)]
        [TestCase("10.454", ExpectedResult = false)]

        public bool IsNegativeTest(object x)
        {
            return Calc.isNegative(x);
        }

        //isPositive
        [Test]
        [TestCase(-10, ExpectedResult = false)]
        [TestCase(-10.454, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = true)]
        [TestCase(10.454, ExpectedResult = true)]
        [TestCase("10.454", ExpectedResult = true)]
        public bool IsPositiveTest(object x)
        {
            return Calc.isPositive(x);
        }

        //Multiply
        [Test]
        [TestCase(2, 2, ExpectedResult = 4)]
        [TestCase(-1, 1, ExpectedResult = -1)]
        [TestCase(0.25, 5, ExpectedResult = 1.25)]
        [TestCase(0, 15, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase("0", "0", ExpectedResult = 0)]

        public double MultiplyTest(double a, double b)
        {
            return Calc.Multiply(a, b);
        }

        //Pow
        [Test]
        [TestCase(10, 15, ExpectedResult = 1000000000000000)]
        [TestCase(-1, 14, ExpectedResult = 1)]
        [TestCase(0, 15, ExpectedResult = 0)]
        [TestCase("2", "2", ExpectedResult = 4)]

        public double PowTest(object a, object b)
        {
            return Calc.Pow(a, b);
        }

        //Sin
        [Test]
        [TestCase(Math.PI / 2, ExpectedResult = 1)]
        [TestCase(3 * Math.PI / 2, ExpectedResult = -1)]
        [TestCase(Math.PI / 6, ExpectedResult = 0.5)]
        [TestCase(Math.PI, ExpectedResult = 0)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase("0", ExpectedResult = 0)]

        public object SinTest(object x)
        {
            return Calc.Sin(x);
        }

        //Sqrt
        [Test]
        [TestCase(4, ExpectedResult = 2)]
        [TestCase(4, ExpectedResult = -2)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(-1, ExpectedResult = double.NaN)]
        [TestCase("4", ExpectedResult = 2)]

        public double SqrtTest(object x)
        {
            return Calc.Sqrt(x);
        }

        //Sub
        [Test]
        [TestCase(1, 1, 0)]
        [TestCase(1, 2, -1)]
        [TestCase(-1, 1, -2)]
        [TestCase(2, 3, -1)]
        [TestCase("1", "1", 0)]

        public void SubTest(object a, object b, object expected)
        {
            Assert.AreEqual(expected, Calc.Sub(a, b));
        }
    }
}

