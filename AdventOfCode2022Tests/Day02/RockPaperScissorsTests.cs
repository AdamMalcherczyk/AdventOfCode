using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Day02;

namespace AdventOfCode2022Tests.Day02
{
    public class RockPaperScissorsTests
    {
        RockPaperScissors _sut;

        string _testInput =
            @"A Y
B X
C Z";

        public RockPaperScissorsTests()
        {
            _sut = new RockPaperScissors();
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

            Assert.Equal("12", result);
        }
    }                                
}                                    