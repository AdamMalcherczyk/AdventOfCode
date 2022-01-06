using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day03;

namespace AdventOfCode2021Tests.Day03
{
    public class BinaryDiagnosticTests
    {
        BinaryDiagnostic _sut;

        string _testInput =
            @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

        public BinaryDiagnosticTests()
        {
            _sut = new BinaryDiagnostic();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("198", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("230", result);
        }
    }                                
}                                    