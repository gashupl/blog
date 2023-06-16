using Pg.Dataverse;
using Xunit;

namespace Pg.Dataverse.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expected = "Hello Peter"; 
            var c = new Class1();
            var actual = c.SayHelloTo("Peter");

            Assert.Equal(expected, actual); 
        }
    }
}