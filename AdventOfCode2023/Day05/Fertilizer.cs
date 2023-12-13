using AdventOfCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day05
{
    internal class Fertilizer : Base
    {
        class Range
        {
            public Range(int sourceStart, int destinationStart, int length)
            {
                SourceStart = sourceStart;
                DestinationStart = destinationStart;
                Length = length;
            }

            public int SourceStart { get; set; }
            public int DestinationStart { get; set; }
            public int Length { get; set; }
        }

        public override string GetFirstResult(string inputText)
        {
            var splitted = inputText.Split("\r\n\r\n");
            int result = 0;

            var seeds = splitted[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));
            var seedToSoilRangs = splitted[1].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var soilToFertilizerRangs = splitted[2].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var fertilizerToWaterRangs = splitted[3].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var waterToLightRangs = splitted[4].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var lightToTemperatureRangs = splitted[5].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var temperatureToHumidityRangs = splitted[6].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var humidityToLocationRangs = splitted[7].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            var splitted = inputText.Split("\r\n\r\n");
            int result = 0;

            var seeds = splitted[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));
            var seedToSoilRangs = splitted[1].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var soilToFertilizerRangs = splitted[2].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var fertilizerToWaterRangs = splitted[3].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var waterToLightRangs = splitted[4].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var lightToTemperatureRangs = splitted[5].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var temperatureToHumidityRangs = splitted[6].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var humidityToLocationRangs = splitted[7].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));

            return result.ToString();
        }
    }
}
