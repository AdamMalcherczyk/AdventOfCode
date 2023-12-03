using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day02
{
    internal class CubeConundrum : Base
    {
        public override string GetFirstResult(string inputText)
        {
            int maxRed = 12;
            int maxGreen = 13;
            int maxBlue = 14;
            int result = 0;

            var game = inputText.Split("\r\n");

            for (int i = 1; i <= game.Length; i++)
            {
                bool failed = false;
                foreach (var round in game[i-1].Split(':')[1].Split(';'))
                {
                    var allNumberWithColorWithinRound = round.Split(',');
                    foreach (var numberWithColorRound in allNumberWithColorWithinRound)
                    {
                        var numberWithColor = numberWithColorRound.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var number = int.Parse(numberWithColor[0]);
                        var color = numberWithColor[1];

                        if (color == "red" && number > maxRed)
                        {
                            failed = true;
                            break;
                        }

                        if (color == "green" && number > maxGreen)
                        {
                            failed = true;
                            break;
                        }

                        if (color == "blue" && number > maxBlue)
                        {
                            failed = true;
                            break;
                        }

                    }

                    if (failed)
                        break;
                }

                result += failed ? 0 : i;
            }

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            int result = 0;

            var game = inputText.Split("\r\n");

            for (int i = 1; i <= game.Length; i++)
            {
                int maxRed = 0;
                int maxGreen = 0;
                int maxBlue = 0;
                foreach (var round in game[i - 1].Split(':')[1].Split(';'))
                {
                    var allNumberWithColorWithinRound = round.Split(',');
                    foreach (var numberWithColorRound in allNumberWithColorWithinRound)
                    {
                        var numberWithColor = numberWithColorRound.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var number = int.Parse(numberWithColor[0]);
                        var color = numberWithColor[1];

                        if (color == "red" && number > maxRed)
                        {
                            maxRed = number;
                        }

                        if (color == "green" && number > maxGreen)
                        {
                            maxGreen = number;
                        }

                        if (color == "blue" && number > maxBlue)
                        {
                            maxBlue = number;
                        }

                    }
                }

                result += maxRed * maxGreen * maxBlue;
            }

            return result.ToString();
        }
    }
}
