using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day02
{
    internal class Dive : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            int result = 0, depth = 0, horizontal = 0;

            var input = inputText.Split("\r\n");

            foreach (var command in input)
            {
                if (command.StartsWith("down"))
                {
                    depth += int.Parse(command.Substring(command.IndexOf(' ') + 1));
                }
                else if (command.StartsWith("up"))
                {
                    depth -= int.Parse(command.Substring(command.IndexOf(' ') + 1));
                }
                else
                {
                    horizontal += int.Parse(command.Substring(command.IndexOf(' ') + 1));
                }
            }

            result = horizontal * depth;

            return result.ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            int result = 0, depth = 0, horizontal = 0, aim = 0;

            var input = inputText.Split("\r\n");

            foreach (var command in input)
            {
                if (command.StartsWith("down"))
                {
                    aim += int.Parse(command.Substring(command.IndexOf(' ') + 1));
                }
                else if (command.StartsWith("up"))
                {
                    aim -= int.Parse(command.Substring(command.IndexOf(' ') + 1));
                }
                else
                {
                    int forward = int.Parse(command.Substring(command.IndexOf(' ') + 1));
                    horizontal += forward;
                    depth += forward * aim;
                }
            }

            result = horizontal * depth;

            return result.ToString();
        }
    }
}
