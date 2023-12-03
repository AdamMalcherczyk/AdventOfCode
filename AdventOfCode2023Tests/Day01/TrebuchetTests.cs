using Xunit;
using AdventOfCode2023.Day01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Tests.Day01
{
    public class TrebuchetTests
    {
        Trebuchet _sut;

        string _testInput =
            @"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet";

        public TrebuchetTests()
        {
            _sut = new Trebuchet();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("142", result);
        }

        string _testInput2 = @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen";

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput2);

            Assert.Equal("281", result);
        }
    }
}