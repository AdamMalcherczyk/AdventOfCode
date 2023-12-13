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
            public Range(long sourceStart, long destinationStart, long length)
            {
                SourceStart = sourceStart;
                DestinationStart = destinationStart;
                Length = length;
            }

            public long SourceStart { get; set; }
            public long DestinationStart { get; set; }
            public long Length { get; set; }
        }

        public override string GetFirstResult(string inputText)
        {
            var splitted = inputText.Split("\r\n\r\n");
            long result = long.MaxValue;

            var seeds = splitted[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x));
            var seedToSoilRangs = splitted[1].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var soilToFertilizerRangs = splitted[2].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var fertilizerToWaterRangs = splitted[3].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var waterToLightRangs = splitted[4].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var lightToTemperatureRangs = splitted[5].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var temperatureToHumidityRangs = splitted[6].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var humidityToLocationRangs = splitted[7].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));

            var maps = new List<IEnumerable<Range>>() 
            { 
                seedToSoilRangs,
                soilToFertilizerRangs,
                fertilizerToWaterRangs,
                waterToLightRangs,
                lightToTemperatureRangs,
                temperatureToHumidityRangs,
                humidityToLocationRangs 
            };

            foreach (var seed in seeds)
            {
                var currentValue = seed;
                foreach (var ranges in maps)
                {
                    var validRange = ranges.FirstOrDefault(x => currentValue >= x.SourceStart && currentValue < (x.SourceStart + x.Length));

                    if (validRange == null)
                        continue;

                    currentValue -= (validRange.SourceStart - validRange.DestinationStart);
                }

                result = Math.Min(result, currentValue);
            }

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            var splitted = inputText.Split("\r\n\r\n");
            long result = long.MaxValue;

            var seeds = splitted[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();
            var seedToSoilRangs = splitted[1].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var soilToFertilizerRangs = splitted[2].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var fertilizerToWaterRangs = splitted[3].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var waterToLightRangs = splitted[4].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var lightToTemperatureRangs = splitted[5].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var temperatureToHumidityRangs = splitted[6].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));
            var humidityToLocationRangs = splitted[7].Split("\r\n").Skip(1).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).Select(x => new Range(x[1], x[0], x[2]));

            var maps = new List<IEnumerable<Range>>()
            {
                seedToSoilRangs,
                soilToFertilizerRangs,
                fertilizerToWaterRangs,
                waterToLightRangs,
                lightToTemperatureRangs,
                temperatureToHumidityRangs,
                humidityToLocationRangs
            };

            //long sumOfSeeds = 0;
            //for (int i = 1; i < seeds.Length; i+=2)
            //{
            //    sumOfSeeds += seeds[i];
            //}

            for (int i = 0; i < seeds.Length; i+=2)
            {
                for (int j = 0; j < seeds[i+1]; j++)
                {
                    var currentValue = seeds[i] + j;
                    foreach (var ranges in maps)
                    {
                        var validRange = ranges.FirstOrDefault(x => currentValue >= x.SourceStart && currentValue < (x.SourceStart + x.Length));

                        if (validRange == null)
                            continue;

                        currentValue -= (validRange.SourceStart - validRange.DestinationStart);
                    }

                    result = Math.Min(result, currentValue);
                }
            }

            return result.ToString();
        }
    }
}
