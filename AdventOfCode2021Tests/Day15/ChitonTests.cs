using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day15;

namespace AdventOfCode2021Tests.Day15
{
    public class ChitonTests
    {
        private Chiton _sut;

        private string _testInput =
            @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581
";
        public ChitonTests()
        {
            _sut = new Chiton();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("40", result);
        }

        [Fact()]
        public void GetSecondResult_ForFirstInputTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("-1", result);
        }
    }
}