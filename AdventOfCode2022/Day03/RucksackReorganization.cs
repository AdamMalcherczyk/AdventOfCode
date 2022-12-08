using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day03
{
    internal class RucksackReorganization : Base
    {
        public override string GetFirstResult(string inputText)
        {
            int result = 0;
            var input = inputText.Split("\r\n");
            var common = input.SelectMany(x => x.Take(x.Length / 2).Intersect(x.Reverse().Take(x.Length / 2)));
            result += common.Where(x => char.IsLower(x)).Select(x => x - 'a' + 1).Sum();
            result += common.Where(x => char.IsUpper(x)).Select(x => x - 'A' + 27).Sum();

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            int result = 0;
            var input = inputText.Split("\r\n");

            char[] common = new char[input.Length / 3];

            for (int i = 0; i < input.Length / 3; i++)
            {
                var segment = input.Skip(i * 3).Take(3).ToArray();
                common[i] = segment[0].Intersect(segment[1]).Intersect(segment[2]).FirstOrDefault();
            }

            result += common.Where(x => char.IsLower(x)).Select(x => x - 'a' + 1).Sum();
            result += common.Where(x => char.IsUpper(x)).Select(x => x - 'A' + 27).Sum();
            return result.ToString();
        }
    }
}
