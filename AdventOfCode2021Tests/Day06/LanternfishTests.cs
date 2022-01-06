using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day06;

namespace AdventOfCode2021Tests.Day06
{
    public class LanternfishTests
    {

        Lanternfish _sut;

        string _testInput =
            @"3,4,3,1,2";

        public LanternfishTests()
        {
            _sut = new Lanternfish();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("5934", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("26984457539", result);
        }
    }
}
