using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day17;

namespace AdventOfCode2021Tests.Day17
{
    public class TrickShotTests
    {
        private string _testInput =
            @"target area: x=20..30, y=-10..-5";

        private TrickShot _sut;
        public TrickShotTests()
        {
            _sut = new TrickShot();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("45", result);
        }

        [Fact()]
        public void GetSecondResult_ForFirstInputTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("-1", result);
        }
    }
}