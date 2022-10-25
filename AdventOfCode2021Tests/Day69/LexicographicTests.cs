using AdventOfCode2021.Day69;
using Xunit;

namespace AdventOfCode2021Tests.Day69
{
    public class LexicographicTests
    {
        private Lexicographic _sut;
        public LexicographicTests()
        {
            _sut = new Lexicographic();
        }

        [Fact()]
        public void GetOneResultTest()
        {
            var result = _sut.GetFirstResult("3");

            Assert.Equal("1", result);
        }

        [Fact()]
        public void GetTwoResultTest()
        {
            var result = _sut.GetFirstResult("3");

            Assert.Equal("2\r\n1 1", result);
        }

        [Fact()]
        public void GetThreeResultTest()
        {
            var result = _sut.GetFirstResult("3");

            Assert.Equal("3\r\n2 1\r\n1 1 1", result);
        }

        [Fact()]
        public void GetFourResultTest()
        {
            var result = _sut.GetFirstResult("4");

            Assert.Equal("4\r\n3 1\r\n2 2\r\n2 1 1\r\n1 1 1 1", result);
        }

        [Fact()]
        public void GetFiveResultTest()
        {
            var result = _sut.GetFirstResult("5");

            Assert.Equal("5\r\n4 1\r\n3 2\r\n3 1 1\r\n2 2 1\r\n2 1 1 1\r\n1 1 1 1 1", result);
        }
    }
}