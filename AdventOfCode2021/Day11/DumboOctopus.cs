using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day11
{
    internal class DumboOctopus : Base
    {
        private int[][] _octopuses;

        internal override string GetFirstResult(string inputText)
        {
            Initialize(inputText);
            var result = PerformNumberOfSteps(100);

            return result.ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            Initialize(inputText);
            int result = WaitForOctopusesToSynchronize();

            return result.ToString();
        }

        internal void Initialize(string inputText)
        {
            _octopuses = inputText.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Select(y => y - '0').ToArray()).ToArray();
        }

        internal int PerformNumberOfSteps(int steps)
        {
            var result = 0;

            for (int i = 0; i < steps; i++)
            {
                IncreaseAllByOne();

                for (int k = 0; k < _octopuses.Length; k++)
                {
                    for (int j = 0; j < _octopuses[k].Length; j++)
                    {
                        if (_octopuses[k][j] == 10)
                        {
                            result += ShineRecurrsivly(k, j);
                        }
                    }
                }

            }

            return result;
        }

        private void IncreaseAllByOne()
        {
            for (int i = 0; i < _octopuses.Length; i++)
            {
                for (int j = 0; j < _octopuses[i].Length; j++)
                {
                    _octopuses[i][j]++;
                }
            }
        }

        private int ShineRecurrsivly(int x, int y)
        {
            if (x < 0 || y < 0 || x > _octopuses.Length - 1 || y > _octopuses[x].Length - 1 || _octopuses[x][y] == 0)
                return 0;

            _octopuses[x][y]++;

            if (_octopuses[x][y] >= 10)
            {
                _octopuses[x][y] = 0;
                return ShineRecurrsivly(x - 1, y - 1) +
                    ShineRecurrsivly(x - 1, y) +
                    ShineRecurrsivly(x - 1, y + 1) +
                    ShineRecurrsivly(x, y - 1) +
                    ShineRecurrsivly(x, y + 1) +
                    ShineRecurrsivly(x + 1, y - 1) +
                    ShineRecurrsivly(x + 1, y) +
                    ShineRecurrsivly(x + 1, y + 1) + 1;
            }

            return 0;
        }

        private int WaitForOctopusesToSynchronize()
        {
            var allOctopuses = _octopuses.Length * _octopuses[0].Length;
            var result = 0;
            var lightedInStep = 0;
            while (lightedInStep != allOctopuses)
            {
                lightedInStep = PerformNumberOfSteps(1);
                result++;
            }

            return result;
        }

        internal string GetOctopuses()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _octopuses.Length; i++)
            {
                for (int j = 0; j < _octopuses[i].Length; j++)
                {
                    sb.Append(_octopuses[i][j]);
                }

                if(i != _octopuses.Length - 1)
                    sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        
    }
}

