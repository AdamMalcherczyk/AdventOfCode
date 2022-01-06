using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day09;

namespace AdventOfCode2021Tests.Day09
{
    public class SmokeBasinTests
    {
        SmokeBasin _sut;

        string _testInput =
            @"2199943210
3987894921
9856789892
8767896789
9899965678";

        public SmokeBasinTests()
        {
            _sut = new SmokeBasin();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("15", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("1134", result);
        }
    }
}