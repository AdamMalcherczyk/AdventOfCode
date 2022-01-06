using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day05;

namespace AdventOfCode2021Tests.Day05
{
    public class HydrothermalVentureTests
    {
        HydrothermalVenture _sut;

        string _testInput =
            @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        public HydrothermalVentureTests()
        {
            _sut = new HydrothermalVenture();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("5", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("12", result);
        }
    }
}
