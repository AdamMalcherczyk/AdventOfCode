using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day16
{
    internal enum PackageType
    {
        Sum = 0,
        Product = 1,
        Min = 2,
        Max = 3,
        Literal = 4,
        GreaterThan = 5,
        LessThan = 6,
        Equal = 7
    }

    internal class Packet
    {
        private long _value;

        public long Version { get; set; }
        public PackageType TypeId { get; set; }
        public long Value { get => CalculateValue(); set => _value = value; }

        public List<Packet> SubPackets { get; set; } = new List<Packet>();

        public long TotalVersionSum { get => SubPackets.Sum(x => x.TotalVersionSum) + Version; }

        private long CalculateValue()
        {
            switch (TypeId)
            {
                case PackageType.Sum:
                    return SubPackets.Sum(x => x.Value);
                case PackageType.Product:
                    return GetProduct();
                case PackageType.Min:
                    return SubPackets.Min(x => x.Value);
                case PackageType.Max:
                    return SubPackets.Max(x => x.Value);
                case PackageType.Literal:
                    return _value;
                case PackageType.GreaterThan:
                    return SubPackets[0].Value > SubPackets[1].Value ? 1 : 0;
                case PackageType.LessThan:
                    return SubPackets[0].Value < SubPackets[1].Value ? 1 : 0;
                case PackageType.Equal:
                    return SubPackets[0].Value == SubPackets[1].Value ? 1 : 0;
                default:
                    //will never happend
                    return 0;
            }
        }

        private long GetProduct()
        {
            var result = 1L;
            foreach (var packet in SubPackets)
            {
                result *= packet.Value;
            }
            return result;
        }
    }

    internal class PacketDecoder : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            Queue<bool> bits = new Queue<bool>();
            var bytes = StringToByteArray(inputText);
            foreach (var word in bytes)
            {
                for (int i = 7; i >= 0; i--)
                {
                    bits.Enqueue((word >> i) % 2 == 1);
                }
            }

            Packet mainPacket = ParsePacket(bits);
            return mainPacket.TotalVersionSum.ToString();
        }

        private Packet ParsePacket(Queue<bool> bits)
        {
            var packet = new Packet();

            packet.Version = GetValueOf(3, bits);
            packet.TypeId = (PackageType)GetValueOf(3, bits);

            if (packet.TypeId == PackageType.Literal)
            {
                bool shouldContinue;
                long value = 0;
                do
                {
                    shouldContinue = GetValueOf(1, bits) == 1;
                    value = GetValueOf(4, bits, value);
                }
                while (shouldContinue);
                packet.Value = value;

                return packet;
            }
            
            long lengthTypeId = GetValueOf(1, bits);
            if (lengthTypeId == 0)
            {
                long subPacketsLength = GetValueOf(15, bits);
                long expectedEndBitCount = bits.Count - subPacketsLength;
                do
                {
                    packet.SubPackets.Add(ParsePacket(bits));
                } while (bits.Count != expectedEndBitCount);

                return packet;
            }

            long subPacketsAmount = GetValueOf(11, bits);
            for (int i = 0; i < subPacketsAmount; i++)
            {
                packet.SubPackets.Add(ParsePacket(bits));
            }

            return packet;
        }

        private long GetValueOf(int numberOfBits, Queue<bool> bits, long initialResult = 0)
        {
            long result = initialResult;
            for (int i = 0; i < numberOfBits; i++)
            {
                if (bits.Dequeue())
                {
                    result = result << 1;
                    result += 1;
                }
                else
                {
                    result = result << 1;
                }
                
            }
            return result;
        }

        internal override string GetSecondResult(string inputText)
        {
            Queue<bool> bits = new Queue<bool>();
            var bytes = StringToByteArray(inputText);
            foreach (var word in bytes)
            {
                for (int i = 7; i >= 0; i--)
                {
                    bits.Enqueue((word >> i) % 2 == 1);
                }
            }

            Packet mainPacket = ParsePacket(bits);
            return mainPacket.Value.ToString();
        }

        private byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}

