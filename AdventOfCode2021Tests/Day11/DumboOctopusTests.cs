using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day11;

namespace AdventOfCode2021Tests.Day11
{
    public class DumboOctopusTests
    {
        private DumboOctopus _sut;

        private string _testInput =
            @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526
";
        public DumboOctopusTests()
        {
            _sut = new DumboOctopus();
        }

        public static IEnumerable<object[]> StepToOctopuses => new List<object[]> {
            new object[] {1, "6594254334\r\n3856965822\r\n6375667284\r\n7252447257\r\n7468496589\r\n5278635756\r\n3287952832\r\n7993992245\r\n5957959665\r\n6394862637" },
            new object[] {2, "8807476555\r\n5089087054\r\n8597889608\r\n8485769600\r\n8700908800\r\n6600088989\r\n6800005943\r\n0000007456\r\n9000000876\r\n8700006848" },
            new object[] {3, "0050900866\r\n8500800575\r\n9900000039\r\n9700000041\r\n9935080063\r\n7712300000\r\n7911250009\r\n2211130000\r\n0421125000\r\n0021119000" },
            new object[] {4, "2263031977\r\n0923031697\r\n0032221150\r\n0041111163\r\n0076191174\r\n0053411122\r\n0042361120\r\n5532241122\r\n1532247211\r\n1132230211" },
            new object[] {5, "4484144000\r\n2044144000\r\n2253333493\r\n1152333274\r\n1187303285\r\n1164633233\r\n1153472231\r\n6643352233\r\n2643358322\r\n2243341322" },
            new object[] {6, "5595255111\r\n3155255222\r\n3364444605\r\n2263444496\r\n2298414396\r\n2275744344\r\n2264583342\r\n7754463344\r\n3754469433\r\n3354452433" },
            new object[] {7, "6707366222\r\n4377366333\r\n4475555827\r\n3496655709\r\n3500625609\r\n3509955566\r\n3486694453\r\n8865585555\r\n4865580644\r\n4465574644" },
            new object[] {8, "7818477333\r\n5488477444\r\n5697666949\r\n4608766830\r\n4734946730\r\n4740097688\r\n6900007564\r\n0000009666\r\n8000004755\r\n6800007755" },
            new object[] {9, "9060000644\r\n7800000976\r\n6900000080\r\n5840000082\r\n5858000093\r\n6962400000\r\n8021250009\r\n2221130009\r\n9111128097\r\n7911119976" },
            new object[] {10, "0481112976\r\n0031112009\r\n0041112504\r\n0081111406\r\n0099111306\r\n0093511233\r\n0442361130\r\n5532252350\r\n0532250600\r\n0032240000" },
            new object[] {20, "3936556452\r\n5686556806\r\n4496555690\r\n4448655580\r\n4456865570\r\n5680086577\r\n7000009896\r\n0000000344\r\n6000000364\r\n4600009543" },
            new object[] {30, "0643334118\r\n4253334611\r\n3374333458\r\n2225333337\r\n2229333338\r\n2276733333\r\n2754574565\r\n5544458511\r\n9444447111\r\n7944446119" },
            new object[] {40, "6211111981\r\n0421111119\r\n0042111115\r\n0003111115\r\n0003111116\r\n0065611111\r\n0532351111\r\n3322234597\r\n2222222976\r\n2222222762" },
            new object[] {50, "9655556447\r\n4865556805\r\n4486555690\r\n4458655580\r\n4574865570\r\n5700086566\r\n6000009887\r\n8000000533\r\n6800000633\r\n5680000538" },
            new object[] {60, "2533334200\r\n2743334640\r\n2264333458\r\n2225333337\r\n2225333338\r\n2287833333\r\n3854573455\r\n1854458611\r\n1175447111\r\n1115446111" },
            new object[] {70, "8211111164\r\n0421111166\r\n0042111114\r\n0004211115\r\n0000211116\r\n0065611111\r\n0532351111\r\n7322235117\r\n5722223475\r\n4572222754" },
            new object[] {80, "1755555697\r\n5965555609\r\n4486555680\r\n4458655580\r\n4570865570\r\n5700086566\r\n7000008666\r\n0000000990\r\n0000000800\r\n0000000000" },
            new object[] { 90, "7433333522\r\n2643333522\r\n2264333458\r\n2226433337\r\n2222433338\r\n2287833333\r\n2854573333\r\n4854458333\r\n3387779333\r\n3333333333" },
            new object[] { 100, "0397666866\r\n0749766918\r\n0053976933\r\n0004297822\r\n0004229892\r\n0053222877\r\n0532222966\r\n9322228966\r\n7922286866\r\n6789998766" },
        };

        [Theory]
        [MemberData(nameof(StepToOctopuses))]
        public void VerifyOctopusesAfterPrefedinedSteps(int step, string octopuses)
        {
            _sut.Initialize(_testInput);
            _sut.PerformNumberOfSteps(step);
            Assert.Equal(octopuses, _sut.GetOctopuses());
        }

        [Fact]
        public void After10Steps_ResultEquals204()
        {
            _sut.Initialize(_testInput);
            var result = _sut.PerformNumberOfSteps(10);
            Assert.Equal(204, result);
        }

        [Fact()]
        public void GetFirstResultTest()
        {
            var result = _sut.GetFirstResult(_testInput);

            Assert.Equal("1656", result);
        }

        [Fact()]
        public void GetSecondResultTest()
        {
            var result = _sut.GetSecondResult(_testInput);

            Assert.Equal("195", result);
        }
    }
}