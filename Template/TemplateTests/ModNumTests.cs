using Template;
using Xunit;

namespace TemplateTests
{
    public class ModNumTests
    {
        const int M = 1000000007;

        [Theory]
        [InlineData(1024, 1024)]
        [InlineData(1000000007, 0)]
        [InlineData(1000001031, 1024)]
        public void XShouldReturnModOf1000000007(int x, int result)
        {
            var modNum = new ModNum(x);
            Assert.Equal(modNum.X, result);
        }

        [Theory]
        [InlineData(1024, 1024)]
        [InlineData(1000001031, 1024)]
        public void EqualsShouldBeTruthy(int a, int b)
        {
            var modNumA = new ModNum(a);
            var modNumB = new ModNum(b);
            Assert.True(modNumA.Equals(modNumB));
            Assert.True(modNumA == modNumB);
            Assert.False(modNumA != modNumB);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1000000008, 1, 2)]
        [InlineData(1000000000, 1024, 1017)]
        public void AdditionShouldReturnModOfSum(int a, int b, int result)
        {
            var modNumA = new ModNum(a);
            var modNumB = new ModNum(b);
            Assert.Equal(modNumA + modNumB, result);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(1000000008, 1, 0)]
        [InlineData(0, 1024, 999998983)]
        public void SubtractionShouldReturnModOfDiff(int a, int b, int result)
        {
            var modNumA = new ModNum(a);
            var modNumB = new ModNum(b);
            Assert.Equal(modNumA - modNumB, result);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(1000000009, 3, 6)]
        [InlineData(1000000000, 3, 999999986)]
        public void MultiplicationShouldReturnModOfProduct(int a, int b, int result)
        {
            var modNumA = new ModNum(a);
            var modNumB = new ModNum(b);
            Assert.Equal(modNumA * modNumB, result);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(1000000013, 3, 2)]
        [InlineData(45000000000, 5, 999999944)]
        [InlineData(45000000000, 5000000000, 9)]
        public void DivisionShouldReturnModOfQuotient(long a, long b, int result)
        {
            var modNumA = new ModNum(a);
            var modNumB = new ModNum(b);
            Assert.Equal(modNumA / modNumB, result);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(1000000009, 2, 4)]
        public void PowShouldReturnModOfPower(int baseNum, int exponent, int result)
        {
            var modNum = new ModNum(baseNum);
            Assert.Equal(ModNum.Pow(modNum, exponent), result);
        }
    }
}
