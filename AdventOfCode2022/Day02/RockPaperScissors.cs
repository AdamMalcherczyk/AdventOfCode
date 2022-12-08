using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day02
{
    internal class RockPaperScissors : Base
    {
        public override string GetFirstResult(string inputText)
        {
            int result = 0;

            var input = inputText.Split("\r\n");

            var wins = input.Where(x => x is "A Y" or "B Z" or "C X").Count();
            var draws = input.Where(x => x is "A X" or "B Y" or "C Z").Count();
            var rocks = input.Where(x => x[2] == 'X').Count();
            var papers = input.Where(x => x[2] == 'Y').Count();
            var scizors = input.Where(x => x[2] == 'Z').Count();

            result = wins * 6 + (scizors + draws) * 3 + rocks + papers + papers;

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            int result = 0;

            var inputs = inputText.Split("\r\n");

            var draws = inputs.Where(x => x[2] == 'Y').Count();
            var wins = inputs.Where(x => x[2] == 'Z').Count();

            var rocks = 0;
            var papers = 0;
            var scizors = 0;

            foreach (var input in inputs)
            {
                if(input[2] == 'X')
                {
                    if (input[0] == 'A') scizors++;
                    else if (input[0] == 'B') rocks++;
                    else papers++;
                }
                else if (input[2] == 'Y')
                {
                    if (input[0] == 'A') rocks++;
                    else if (input[0] == 'B') papers++;
                    else scizors++;
                }
                else
                {
                    if (input[0] == 'A') papers++;
                    else if (input[0] == 'B') scizors++;
                    else rocks++;
                }
            }

            result = wins * 6 + (scizors + draws) * 3 + rocks + papers + papers;

            return result.ToString();
        }
    }
}
