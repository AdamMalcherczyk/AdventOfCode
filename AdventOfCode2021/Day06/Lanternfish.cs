using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day06
{
    internal class Lanternfish : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            var fish = inputText.Split(',').Select(x => x[0] - '0').ToList();
            Dictionary<int, int> fishes = new Dictionary<int, int>();
            for (int i = 0; i <= 8; i++)
            {
                fishes.Add(i, fish.Count(x => x == i));
            }

            for (int i = 0; i < 80; i++)
            {
                int temp = fishes[0];
                for (int j = 0; j < 8; j++)
                {
                    fishes[j] = fishes[j + 1];
                }
                fishes[6] += temp;
                fishes[8] = temp;
            }
            return fishes.Values.Sum().ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            var fish = inputText.Split(',').Select(x => x[0] - '0').ToList();
            Dictionary<int, long> fishes = new Dictionary<int, long>();
            for (int i = 0; i <= 8; i++)
            {
                fishes.Add(i, fish.Count(x => x == i));
            }

            for (int i = 0; i < 256; i++)
            {
                long temp = fishes[0];
                for (int j = 0; j < 8; j++)
                {
                    fishes[j] = fishes[j + 1];
                }
                fishes[6] += temp;
                fishes[8] = temp;
            }
            return fishes.Values.Sum().ToString();
        }
    }
}
