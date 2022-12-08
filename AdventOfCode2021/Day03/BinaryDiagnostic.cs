using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day03
{
    internal class BinaryDiagnostic : Base
    {
        public override string GetFirstResult(string inputText)
        {
            int result = 0, gamma = 0, epsilon = 0;

            var input = inputText.Split("\r\n");

            string binGamma = "";

            for (int i = 0; i < input[0].Length; i++)
            {
                var sum = input.Select(x => x[i] - '0').Sum();

                if (sum > input.Length / 2)
                    binGamma += '1';
                else
                    binGamma += '0';
            }

            gamma = Convert.ToInt32(binGamma, 2);

            epsilon = (int)Math.Pow(2, input[0].Length) - 1 - gamma;

            result = gamma * epsilon;

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            int result = 0, oxygen = 0, co2 = 0;

            var input = inputText.Split("\r\n");

            var filteredInputs = input.ToList();
            for (int i = 0; i < input[0].Length; i++)
            {
                var sum = filteredInputs.Select(x => x[i] - '0').Sum();
                int highOrLow;
                if (filteredInputs.Count() > sum * 2)
                    highOrLow = 0;
                else
                    highOrLow = 1;

                filteredInputs = filteredInputs.Where(x => x[i] == '0' + highOrLow).ToList();

                if (filteredInputs.Count() == 1)
                    break;

            }

            oxygen = Convert.ToInt32(filteredInputs.First(), 2);

            filteredInputs = input.ToList();
            for (int i = 0; i < input[0].Length; i++)
            {
                var sum = filteredInputs.Select(x => x[i] - '0').Sum();
                int highOrLow;
                if (filteredInputs.Count() > sum * 2)
                    highOrLow = 1;
                else
                    highOrLow = 0;

                filteredInputs = filteredInputs.Where(x => x[i] == '0' + highOrLow).ToList();

                if (filteredInputs.Count() == 1)
                    break;

            }

            co2 = Convert.ToInt32(filteredInputs.First(), 2);

            result = oxygen * co2;

            return result.ToString();
        }
    }
}
