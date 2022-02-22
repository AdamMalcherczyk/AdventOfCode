using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day14;

namespace AdventOfCode2021Tests.Day14
{
    public class ExtendedPolymerizationTests
    {
        private ExtendedPolymerization _sut;

        private string _testInput =
            @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C
";
        public ExtendedPolymerizationTests()
        {
            _sut = new ExtendedPolymerization();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("1588", result);
        }

        [Fact()]
        public void GetSecondResult_ForFirstInputTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("-1", result);
        }
    }
}