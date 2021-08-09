using System;
using Xunit;

namespace CalcTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var calc =  new Calculator.Calculator();

            var math = "(2+4*3)-1";
            var expected = "13";

            var result = calc.Calculate(math);
            Assert.Equal(expected, result);
            
        }
    }
}
