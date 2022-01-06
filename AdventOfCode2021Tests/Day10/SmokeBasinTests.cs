using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day10;

namespace AdventOfCode2021Tests.Day10
{
    public class SyntaxScoringTests
    {
        SyntaxScoring _sut;

        string _testInput =
            @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

        public SyntaxScoringTests()
        {
            _sut = new SyntaxScoring();
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("26397", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("-1", result);
        }
    }
}