using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Day04;

namespace AdventOfCode2021Tests.Day04
{
    public class CampCleanupTests
    {
        CampCleanup _sut;

        string _testInput =
            @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

        public CampCleanupTests()
        {
            _sut = new CampCleanup();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("2", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("4", result);
        }
    }                                
}                                    