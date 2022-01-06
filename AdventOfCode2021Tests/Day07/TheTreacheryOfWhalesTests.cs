using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day07;

namespace AdventOfCode2021Tests.Day07
{
    public class TheTreacheryOfWhalesTests
    {
        TheTreacheryOfWhales _sut;

        string _testInput =
            @"16,1,2,0,4,2,7,1,2,14";

        public TheTreacheryOfWhalesTests()
        {
            _sut = new TheTreacheryOfWhales();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("37", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("168", result);
        }
    }                                
}                                    