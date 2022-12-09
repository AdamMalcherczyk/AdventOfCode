using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day04
{
    internal class CampCleanup : Base
    {
        public override string GetFirstResult(string inputText)
        {
            var pairs = inputText.Split("\r\n");

            var result = 0;
            foreach (var pair in pairs)
            {
                var duty = pair.Split(',');

                var minFirst = int.Parse(duty[0].Split('-')[0]);
                var maxFirst = int.Parse(duty[0].Split('-')[1]);
                var minSecond = int.Parse(duty[1].Split('-')[0]);
                var maxSecond = int.Parse(duty[1].Split('-')[1]);

                if (minFirst >= minSecond && maxFirst <= maxSecond)
                    result++;

                else if (minSecond >= minFirst && maxSecond <= maxFirst)
                    result++;
            }
            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            var pairs = inputText.Split("\r\n");

            var result = 0;
            foreach (var pair in pairs)
            {
                var duty = pair.Split(',');

                var minFirst = int.Parse(duty[0].Split('-')[0]);
                var maxFirst = int.Parse(duty[0].Split('-')[1]);
                var minSecond = int.Parse(duty[1].Split('-')[0]);
                var maxSecond = int.Parse(duty[1].Split('-')[1]);

                if (Math.Max(maxFirst, maxSecond) - Math.Min(minFirst, minSecond) + 1 < (maxFirst - minFirst + 1) + (maxSecond - minSecond + 1))
                    result++;
            }
            return result.ToString();
        }
    }
}
