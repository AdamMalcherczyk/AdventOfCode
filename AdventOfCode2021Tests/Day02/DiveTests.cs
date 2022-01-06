using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day02;

namespace AdventOfCode2021Tests.Day02
{
    public class DiveTests
    {
        Dive _sut;

        string _testInput =
            @"forward 5
down 5
forward 8
up 3
down 8
forward 2";

        public DiveTests()
        {
            _sut = new Dive();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("150", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("900", result);
        }
    }                                
}                                    