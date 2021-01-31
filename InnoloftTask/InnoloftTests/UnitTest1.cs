using Xunit;

namespace InnoloftTests
{
    public class UnitTest1
    {

        [Fact]
        public void TestSum()
        {
            int v1 = 1;
            int v2 = 2;
            Assert.True(v1 + v2 == 3);
            Assert.False(v1 + v2 == 4);

        }
    }
}