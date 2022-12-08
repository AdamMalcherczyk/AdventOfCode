using Xunit;
using AdventOfCode2022.Day01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Tests.Day01
{
    public class CalorieCountingTests
    {
        CalorieCounting _sut;

        string _testInput =
            @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

        public CalorieCountingTests()
        {
            _sut = new CalorieCounting();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("24000", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("45000", result);
        }
    }                                
}                                    