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
        public PacketDecoderTests()
        {
            _sut = new PacketDecoder();
        }

        [Theory()]
        [InlineData("8A004A801A8002F478", "16")]
        [InlineData("620080001611562C8802118E34", "12")]
        [InlineData("C0015000016115A2E0802F182340", "23")]
        [InlineData("A0016C880162017C3686B18A3D4780", "31")]
        public void GetFirstResultTest(string input, string output)
        {
            var result = _sut.GetFirstResult(input);

            Assert.Equal(output, result);
        }

        [Theory()]
        [InlineData("C200B40A82", "3")]
        [InlineData("04005AC33890", "54")]
        [InlineData("880086C3E88112", "7")]
        [InlineData("CE00C43D881120", "9")]
        [InlineData("D8005AC2A8F0", "1")]
        [InlineData("F600BC2D8F", "0")]
        [InlineData("9C005AC2F8F0", "0")]
        [InlineData("9C0141080250320F1802104A08", "1")]
        public void GetSecondResult_ForFirstInputTest(string input, string output)
        {
            var result = _sut.GetSecondResult(input);

            Assert.Equal(output, result);
        }
    }
}