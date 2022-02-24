using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day16;

namespace AdventOfCode2021Tests.Day16
{
    public class PacketDecoderTests
    {
        private PacketDecoder _sut;

        private const string _testInput = @"8A004A801A8002F478";
        private const string _testInput2 = @"620080001611562C8802118E34";
        private const string _testInput3 = @"C0015000016115A2E0802F182340";
        private const string _testInput4 = @"A0016C880162017C3686B18A3D4780";
        public PacketDecoderTests()
        {
            _sut = new PacketDecoder();
        }

        [Theory()]
        [InlineData(_testInput, "16")]
        [InlineData(_testInput2, "12")]
        [InlineData(_testInput3, "23")]
        [InlineData(_testInput4, "31")]
        public void GetFirstResultTest(string input, string output)
        {
            var result = _sut.GetFirstResult(input);

            Assert.Equal(output, result);
        }

        [Theory()]
        [InlineData(_testInput, "-1")]
        [InlineData(_testInput2, "-1")]
        [InlineData(_testInput3, "-1")]
        [InlineData(_testInput4, "-1")]
        public void GetSecondResult_ForFirstInputTest(string input, string output)
        {
            var result = _sut.GetSecondResult(input);

            Assert.Equal(output, result);
        }
    }
}