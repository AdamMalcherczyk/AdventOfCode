using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day04;

namespace AdventOfCode2021Tests.Day04
{
    public class GiantSquidTests
    {
        GiantSquid _sut;

        string _testInput =
            @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

        public GiantSquidTests()
        {
            _sut = new GiantSquid();
        }

        [Fact()]
        public void Input_Test()
        {
            Input input = new Input(_testInput);
            Assert.Equal(new List<int> { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 }, input.NumberSequence);

            Assert.Equal(3, input.Boards.Count);

            foreach (var board in input.Boards)
            {
                Assert.Equal(10, board.Lines.Length);
            }

            Assert.Equal(new int[] { 22, 13, 17, 11, 0 }, input.Boards[0].Lines[0]);
            Assert.Equal(new int[] { 22, 8, 21, 6, 1 }, input.Boards[0].Lines[5]);
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("4512", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("1924", result);
        }
    }                                
}                                    