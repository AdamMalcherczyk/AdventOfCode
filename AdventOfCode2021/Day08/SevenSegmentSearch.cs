using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day08
{
    internal class SevenSegmentSearch : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            var outputs = inputText.Split("\r\n").SelectMany(x => x.Split('|')[1].Split(' '));
            return outputs.Count(x => x.Length == 2 || x.Length == 4 || x.Length == 3 || x.Length == 7).ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            var inputs = inputText.Split("\r\n");

            var result = 0;

            foreach (var input in inputs)
            {
                var splitted = input.Split(" | ");
                var data = splitted[0].Split(' ').Select(x => new string(x.ToCharArray().OrderBy(x => x).ToArray()));
                var outputValues = splitted[1].Split(' ').Select(x => new string(x.ToCharArray().OrderBy(x => x).ToArray())).ToArray();

                var signals = data.SelectMany(x => x.ToCharArray().Select(y => y - 'a'));

                int[] numberOfAllSignals = new int[7];
                foreach (var signal in signals)
                {
                    numberOfAllSignals[signal]++;
                }

                var values = new string[10];
                values[1] = data.First(x => x.Length == 2);
                values[2] = data.First(x => x.Length == 5 && x.Contains(Convert.ToChar(Array.IndexOf(numberOfAllSignals, 4) + 'a')));
                values[3] = data.First(x => x.Length == 5 && x.Contains(Convert.ToChar(Array.IndexOf(numberOfAllSignals, 6) + 'a')) == false && x != values[2]);
                values[4] = data.First(x => x.Length == 4);
                values[5] = data.First(x => x.Length == 5 && x != values[2] && x != values[3]);
                values[7] = data.First(x => x.Length == 3);
                values[8] = data.First(x => x.Length == 7);
                values[9] = data.First(x => x.Length == 6 && x.Contains(Convert.ToChar(Array.IndexOf(numberOfAllSignals, 4) + 'a')) == false);
                values[0] = data.First(x => x.Length == 6 && x.Contains(values[1][0]) && x.Contains(values[1][1]) && x != values[9]);
                values[6] = data.First(x => x.Length == 6 && x != values[0] && x != values[9]);

                var partialResult = Array.IndexOf(values, outputValues[0]) * 1000 + Array.IndexOf(values, outputValues[1]) * 100 + Array.IndexOf(values, outputValues[2]) * 10 + Array.IndexOf(values, outputValues[3]);

                result += partialResult;
            }

            return result.ToString();
        }
    }
}
