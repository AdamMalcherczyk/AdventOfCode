using Xunit;
using AdventOfCode2021.Day01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021Tests.Day01
{
    public class SonarSweepTests
    {
        SonarSweep _sut;

        string _testInput =
            @"199
200
208
210
200
207
240
269
260
263";

        public SonarSweepTests()
        {
            _sut = new SonarSweep();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("7", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("5", result);
        }
    }                                
}                                    