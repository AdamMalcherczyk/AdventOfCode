using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day01
{
    internal class Trebuchet : Base
    {
        public override string GetFirstResult(string inputText)
        {
            int result = 0;

            var inputs = inputText.Split("\r\n");

            for (int i = 0; i < inputs.Count(); i++)
            {
                result += (inputs[i].First(x => Char.IsNumber(x)) - '0') * 10;
                result += inputs[i].Last(x => Char.IsNumber(x)) - '0';
            }

            return result.ToString();
        }

        private readonly string[] _spelledOutNumbers = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public override string GetSecondResult(string inputText)
        {
            // for sure we can do some naive calculation, like replacing all spellout numbers with their digit counterparts
            // it might not be the most efficient solution
            // better option in my head is to find index of first and last spelled out number and compare it to index of real number
            // replace is easier and fast enough, maybe I will optimize it later (said noone ever)

            int result = 0;

            var inputs = inputText.Split("\r\n");

            for (int i = 0; i < inputs.Count(); i++)
            {
                int minIndex = inputs[i].Length;
                int minNumber = 10;
                int maxIndex = -1;
                int maxNumber = -1;
                for (int j = 0; j < 10; j++)
                {
                    var tempMinIndexSpelledOut = inputs[i].IndexOf(_spelledOutNumbers[j]);
                    if (tempMinIndexSpelledOut == -1)
                        tempMinIndexSpelledOut = inputs[i].Length;
                    var tempMaxIndexSpelledOut = inputs[i].LastIndexOf(_spelledOutNumbers[j]);

                    var tempMinIndex = inputs[i].IndexOf(j.ToString());
                    if (tempMinIndex == -1)
                        tempMinIndex = inputs[i].Length;

                    tempMinIndex = Math.Min(tempMinIndexSpelledOut, tempMinIndex);
                    var tempMaxIndex = inputs[i].LastIndexOf(j.ToString());
                    tempMaxIndex = Math.Max(tempMaxIndexSpelledOut, tempMaxIndex);

                    if (tempMinIndex < minIndex) 
                    { 
                        minIndex = tempMinIndex;
                        minNumber = j;
                    }

                    if (tempMaxIndex > maxIndex)
                    {
                        maxIndex = tempMaxIndex;
                        maxNumber = j;
                    }
                }

                result += minNumber * 10;
                result += maxNumber;
            }

            return result.ToString();
        }
    }
}
