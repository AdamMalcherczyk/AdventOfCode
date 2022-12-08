using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day01
{
    internal class SonarSweep : Base
    {
        public override string GetFirstResult(string inputText)
        {
            int result = 0;

            var input = inputText.Split("\r\n").Select(x => int.Parse(x));

            result = Enumerable.Range(1, input.Count() - 1).Count(x => input.ElementAt(x - 1) < input.ElementAt(x));

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            int result = 0;

            var input = inputText.Split("\r\n").Select(x => int.Parse(x));

            var transformed = Enumerable.Range(0, input.Count() - 2).Select(x => input.ElementAt(x) + input.ElementAt(x + 1) + input.ElementAt(x + 2));

            result = Enumerable.Range(1, transformed.Count() - 1).Count(x => transformed.ElementAt(x - 1) < transformed.ElementAt(x));

            return result.ToString();
        }
    }
}
