using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day07
{
    internal class TheTreacheryOfWhales : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            var crabs = inputText.Split(',').Select(x => int.Parse(x)).ToList();
            var crabLength = crabs.Count;
            var value = 0;
            var mostEfficient = 0;
            while (value < crabLength / 2)
            {
                value += crabs.Count(x => x == mostEfficient);
                mostEfficient++;
            }
            mostEfficient -= 1;


            return crabs.Select(x => Math.Abs(x - mostEfficient)).Sum().ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            Dictionary<int, int> cost = new Dictionary<int, int>();
            var crabs = inputText.Split(',').Select(x => int.Parse(x)).ToList();

            cost.Add(0, crabs.Select(x => x * (x + 1) / 2).Sum());

            int index = 0;
            do
            {
                var sum = crabs.Select(x => index - x).Sum();
                cost.Add(index + 1, cost[index] + sum + crabs.Count(x => x <= index));
                index++;
            } while (cost[index - 1] - cost[index] > 0);

            return cost[index - 1].ToString();
        }
    }
}
