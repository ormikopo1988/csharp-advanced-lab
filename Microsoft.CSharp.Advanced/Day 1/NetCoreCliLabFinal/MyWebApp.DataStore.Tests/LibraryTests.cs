using Xunit;

namespace MyWebApp.DataStore.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void TestThing()
        {
            Assert.Equal(42, new Thing().Get(19, 23));
        }
    }
}