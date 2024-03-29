﻿using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day18;

namespace AdventOfCode2021Tests.Day18
{
    public class SnailfishTests
    {
        private Snailfish _sut;
        public SnailfishTests()
        {
            _sut = new Snailfish();
        }

        [Theory()]
        [InlineData("[1,2]", 0, 1, 2)]
        [InlineData("[[1,2]]", 1, 1, 2)]
        [InlineData("[[[1,2]]]", 2, 1, 2)]
        [InlineData("[[[[1,2]]]]", 3, 1, 2)]
        [InlineData("[[[[[1,2]]]]]", 4, 1, 2)]
        public void InputReadSinglePairTest(string input, int nestLevel, int leftValue, int rightValue)
        {
            var parsed = _sut.Parse(input);
            Assert.Equal(nestLevel, parsed.Pairs[0].NestLevel);
            Assert.Equal(leftValue, parsed.Pairs[0].Left.Value);
            Assert.Equal(rightValue, parsed.Pairs[0].Right.Value);
            Assert.Single(parsed.Pairs);
        }

        [Fact()]
        public void InputReadPairAndNumberTest()
        {
            var parsed = _sut.Parse("[[3,6],9]");
            Assert.Equal(1, parsed.Pairs[0].NestLevel);
            Assert.Equal(3, parsed.Pairs[0].Left.Value);
            Assert.Equal(6, parsed.Pairs[0].Right.Value);
            Assert.Equal(2, parsed.Pairs.Count);
            Assert.Equal(parsed.Pairs[0], parsed.Pairs[1].Left);
            Assert.Equal(9, parsed.Pairs[1].Right.Value);
            Assert.Equal(0, parsed.Pairs[1].NestLevel);
        }
        
        [Fact()]
        public void InputReadNumberAndPairTest()
        {
            var parsed = _sut.Parse("[3,[6,9]]");
            Assert.Equal(0, parsed.Pairs[0].NestLevel);
            Assert.Equal(3, parsed.Pairs[0].Left.Value);
            Assert.Equal(parsed.Pairs[1], parsed.Pairs[0].Right);
            Assert.Equal(2, parsed.Pairs.Count);
            Assert.Equal(6, parsed.Pairs[1].Left.Value);
            Assert.Equal(9, parsed.Pairs[1].Right.Value);
            Assert.Equal(1, parsed.Pairs[1].NestLevel);
        }
        
        [Fact()]
        public void InputReadComplicatedTest()
        {
            var parsed = _sut.Parse("[[[[[9,8],1],2],3],4]");
            Assert.Equal(5, parsed.Pairs.Count);
            Assert.Equal(4, parsed.Pairs[0].NestLevel);
            Assert.Equal(9, parsed.Pairs[0].Left.Value);
            Assert.Equal(8, parsed.Pairs[0].Right.Value);
            
            Assert.Equal(3, parsed.Pairs[1].NestLevel);
            Assert.Equal(parsed.Pairs[0], parsed.Pairs[1].Left);
            Assert.Equal(1, parsed.Pairs[1].Right.Value);

            Assert.Equal(2, parsed.Pairs[2].NestLevel);
            Assert.Equal(parsed.Pairs[1], parsed.Pairs[2].Left);
            Assert.Equal(2, parsed.Pairs[2].Right.Value);

            Assert.Equal(1, parsed.Pairs[3].NestLevel);
            Assert.Equal(parsed.Pairs[2], parsed.Pairs[3].Left);
            Assert.Equal(3, parsed.Pairs[3].Right.Value);

            Assert.Equal(0, parsed.Pairs[4].NestLevel);
            Assert.Equal(parsed.Pairs[3], parsed.Pairs[4].Left);
            Assert.Equal(4, parsed.Pairs[4].Right.Value);
        }
        
        [Fact()]
        public void InputReadAnotherComplicatedTest()
        {
            var parsed = _sut.Parse("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]");
            Assert.Equal(1, parsed.Pairs[0].NestLevel);
            Assert.Equal(3, parsed.Pairs[0].Left.Value);
            Assert.Equal(parsed.Pairs[1], parsed.Pairs[0].Right);
            
            Assert.Equal(2, parsed.Pairs[1].NestLevel);
            Assert.Equal(2, parsed.Pairs[1].Left.Value);
            Assert.Equal(parsed.Pairs[2], parsed.Pairs[1].Right);

            Assert.Equal(3, parsed.Pairs[2].NestLevel);
            Assert.Equal(1, parsed.Pairs[2].Left.Value);
            Assert.Equal(parsed.Pairs[3], parsed.Pairs[2].Right);

            Assert.Equal(4, parsed.Pairs[3].NestLevel);
            Assert.Equal(7, parsed.Pairs[3].Left.Value);
            Assert.Equal(3, parsed.Pairs[3].Right.Value);

            Assert.Equal(0, parsed.Pairs[4].NestLevel);
            Assert.Equal(parsed.Pairs[3], parsed.Pairs[4].Left);
            Assert.Equal(parsed.Pairs[5], parsed.Pairs[4].Right);

            Assert.Equal(1, parsed.Pairs[5].NestLevel);
            Assert.Equal(6, parsed.Pairs[5].Left.Value);
            Assert.Equal(parsed.Pairs[6], parsed.Pairs[5].Right);

            Assert.Equal(2, parsed.Pairs[6].NestLevel);
            Assert.Equal(5, parsed.Pairs[6].Left.Value);
            Assert.Equal(parsed.Pairs[7], parsed.Pairs[6].Right);

            Assert.Equal(3, parsed.Pairs[7].NestLevel);
            Assert.Equal(4, parsed.Pairs[7].Left.Value);
            Assert.Equal(parsed.Pairs[8], parsed.Pairs[7].Right);

            Assert.Equal(4, parsed.Pairs[8].NestLevel);
            Assert.Equal(3, parsed.Pairs[8].Left.Value);
            Assert.Equal(2, parsed.Pairs[8].Right.Value);
        }

        [Fact()]
        public void NestedFourLeftMostNumber_PairExplosionLeftNumberIsOutTest()
        {
            var input = "[[[[[9,8],1],2],3],4]";
            var output = "[[[[0,9],2],3],4]";

            Assert.True(false, "Not implemented");
        }
        
        [Fact()]
        public void NestedFourRightMostNumber_PairExplosionRightNumberIsOutTest()
        {
            var input = "[7,[6,[5,[4,[3,2]]]]]";
            var output = "[7,[6,[5,[7,0]]]]";
            Assert.True(false, "Not implemented");
        }

        [Fact()]
        public void NestedFourCenterPair_ExplosionTest()
        {
            var input = "[[6,[5,[4,[3, 2]]]],1]";
            var output = "[[6,[5,[7,0]]],3]";
            Assert.True(false, "Not implemented");
        }
        
        [Fact()]
        public void NestedFour_DoubleExplosionTest()
        {
            var input = "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]";
            var output1 = "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]";
            var output2 = "[[3,[2,[8,0]]],[9,[5,[7,0]]]]";
            Assert.True(false, "Not implemented");
        }

        [Theory()]
        [InlineData("[10]","[5,5]")]
        [InlineData("[11]","[5,6]")]
        [InlineData("[12]","[6,6]")]
        [InlineData("[13]","[6,7]")]
        [InlineData("[14]","[7,7]")]
        [InlineData("[15]","[7,8]")]
        [InlineData("[16]","[8,8]")]
        [InlineData("[17]","[8,9]")]
        [InlineData("[18]","[9,9]")]
        public void GreaterThan10_PairSplitTest(string input, string output)
        {
            Assert.True(false, "Not implemented");
        }

        [Theory()]
        [InlineData("[1,1]\r\n[2,2]\r\n[3,3]\r\n[4,4]", "[[[[1,1],[2,2]],[3,3]],[4,4]]")]
        [InlineData("[1,1]\r\n[2,2]\r\n[3,3]\r\n[4,4]\r\n[5,5]", "[[[[3,0],[5,3]],[4,4]],[5,5]]")]
        [InlineData("[1,1]\r\n[2,2]\r\n[3,3]\r\n[4,4]\r\n[5,5]\r\n[6,6]", "[[[[5,0],[7,4]],[5,5]],[6,6]]")]
        [InlineData("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]\r\n" +
            "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]\r\n" +
            "[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]\r\n" +
            "[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]\r\n" +
            "[7,[5,[[3,8],[1,4]]]]\r\n" +
            "[[2,[2,2]],[8,[8,1]]]\r\n[2,9]\r\n" +
            "[1,[[[9,3],9],[[9,0],[0,7]]]]\r\n" +
            "[[[5,[7,4]],7],1]\r\n" +
            "[[[[4,2],2],6],[8,7]]", "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")]
        public void CalulateFinalSumTest(string input, string output)
        {
            Assert.True(false, "Not implemented");
        }

        [Theory]
        [InlineData("[9,1]", 29)]
        [InlineData("[1,9]", 21)]
        [InlineData("[[9,1],[1,9]]", 129)]
        [InlineData("[[1,2],[[3,4],5]]", 143)]
        [InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
        [InlineData("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
        [InlineData("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
        [InlineData("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
        [InlineData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
        public void CalulateMagnitudeTest(string input, int output)
        {
            Assert.True(false, "Not implemented");
        }

        private string _testInput =
    @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("4140", result);
        }

        [Fact()]
        public void GetSecondResult_ForFirstInputTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("-1", result);
        }
    }
}