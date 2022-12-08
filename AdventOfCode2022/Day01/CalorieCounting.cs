using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day01
{
    internal class CalorieCounting : Base
    {
        public override string GetFirstResult(string inputText)
        {
            int result = 0;

            var inputs = inputText.Split("\r\n").Select(x => (int.TryParse(x, out int calorie), calorie)).ToArray();

            int tempSum = 0;
            for (int i = 0; i < inputs.Count(); i++)
            {
                if (inputs[i].Item1)
                {
                    tempSum += inputs[i].calorie;
                }
                else
                {
                    if(result < tempSum)
                        result = tempSum;
                    tempSum = 0;
                }
            }

            if (result < tempSum)
                result = tempSum;

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            List<int> results = new List<int>();
            var inputs = inputText.Split("\r\n").Select(x => (int.TryParse(x, out int calorie), calorie)).ToArray();

            int tempSum = 0;
            for (int i = 0; i < inputs.Count(); i++)
            {
                if (inputs[i].Item1)
                {
                    tempSum += inputs[i].calorie;
                }
                else
                {
                    results.Add(tempSum);
                    tempSum = 0;
                }
            }

            results.Add(tempSum);

            results.Sort();
            results.Reverse();

            return results.Take(3).Sum().ToString();
        }
    }
}
