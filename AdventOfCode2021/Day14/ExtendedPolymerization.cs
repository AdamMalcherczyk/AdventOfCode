using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day14
{
    internal class ExtendedPolymerization : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            string polymerRaw;
            Dictionary<string, string> extensions;
            Dictionary<string, long> polymers;
            Initialize(inputText, out polymerRaw, out extensions, out polymers);

            for (int i = 0; i < 10; i++)
            {
                polymers = ExtendPolymers(extensions, polymers);
            }

            // we need to add first letter which is not counted for
            polymers[polymerRaw[0].ToString() + polymerRaw[0].ToString()]++;

            return GetResult(polymers);
        }


        internal override string GetSecondResult(string inputText)
        {
            string polymerRaw;
            Dictionary<string, string> extensions;
            Dictionary<string, long> polymers;
            Initialize(inputText, out polymerRaw, out extensions, out polymers);

            for (int i = 0; i < 40; i++)
            {
                polymers = ExtendPolymers(extensions, polymers);
            }

            // we need to add first letter which is not counted for
            polymers[polymerRaw[0].ToString() + polymerRaw[0].ToString()]++;

            return GetResult(polymers);
        }

        private static void Initialize(string inputText, out string polymerRaw, out Dictionary<string, string> extensions, out Dictionary<string, long> polymers)
        {
            var inputRaw = inputText.Split("\r\n\r\n");
            polymerRaw = inputRaw[0];
            var extensionsRaw = inputRaw[1];

            extensions = extensionsRaw.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToDictionary(x => x.Split(" -> ")[0], x => x.Split(" -> ")[1]);
            polymers = extensions.Keys.ToDictionary(x => x, x => 0L);
            for (int i = 0; i < polymerRaw.Length - 1; i++)
            {
                polymers[polymerRaw.Substring(i, 2)]++;
            }
        }

        private static Dictionary<string, long> ExtendPolymers(Dictionary<string, string> extensions, Dictionary<string, long> polymers)
        {
            var tempPolymers = polymers.ToDictionary(x => x.Key, y => y.Value);

            foreach (var polymer in polymers.Keys)
            {
                var amount = polymers[polymer];

                if (amount == 0)
                    continue;

                var extension = extensions[polymer];
                tempPolymers[polymer] -= amount;

                var left = polymer[0].ToString() + extension;
                var right = extension + polymer[1].ToString();

                tempPolymers[left] += amount;
                tempPolymers[right] += amount;
            }

            return tempPolymers;
        }

        private static string GetResult(Dictionary<string, long> polymers)
        {
            var letters = string.Join("", polymers.Keys).Distinct().ToDictionary(x => x, x => 0L);

            foreach (var letter in letters.Keys)
            {
                foreach (var polymer in polymers.Keys.Where(x => x[1] == letter))
                {
                    letters[letter] += polymers[polymer];
                }
            }

            return (letters.Values.Max() - letters.Values.Min()).ToString();
        }
    }
}

