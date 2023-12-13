using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day04
{
    internal class Scratchcards : Base
    {
        public override string GetFirstResult(string inputText)
        {
            var cards = inputText.Split("\r\n");
            var result = 0;

            foreach (var card in cards)
            {
                var splitted = card.Split('|', ':');
                var winning = splitted[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                var mine = splitted[2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

                var all = winning.Union(mine).Distinct().ToArray();

                var matches = winning.Length + mine.Length - all.Length;
                result += matches == 0 ? 0 : (int)Math.Pow(2, matches - 1);
            }

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            var cards = inputText.Split("\r\n");
            var result = 0;

            var cardNo = 0;
            int[] winnings = null;

            foreach (var card in cards)
            {
                var splitted = card.Split('|', ':');
                var winning = splitted[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                var mine = splitted[2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

                var winningsLength = winning.Length + 1;

                winnings ??= new int[winningsLength];
                winnings[cardNo % winningsLength]++;

                var all = winning.Union(mine).Distinct().ToArray();

                var matches = winning.Length + mine.Length - all.Length;

                for (int i = 1; i <= matches; i++)
                {
                    winnings[(cardNo + i) % winningsLength] += winnings[cardNo % winningsLength];
                }

                result += winnings[cardNo % winningsLength];

                winnings[cardNo % winningsLength] = 0;
                cardNo++;
            }

            return result.ToString(); //8129691
        }
    }
}
