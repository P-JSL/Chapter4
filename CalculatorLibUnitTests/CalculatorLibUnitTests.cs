using Xunit;
using Packt;

namespace CalculatorLibUnitTests
{
    public class CalculatorLibUnitTests
    {
        [Fact]
        public void Test1()
        {
            double a = 2;
            double b = 2;
            double excepted = 4;
            var calc = new Calculator();
            double actual = calc.Add(a, b);
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void TestAdding2And3() 
        {
            double a = 2;
            double b = 3;
            double excepted = 5;
            var calc = new Calculator();
            double actual = calc.Add(a, b);
            Assert.Equal(excepted, actual);
        }
    }
}