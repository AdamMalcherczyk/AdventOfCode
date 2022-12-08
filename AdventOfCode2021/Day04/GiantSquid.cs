using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04
{
    internal class GiantSquid : Base
    {
        public override string GetFirstResult(string inputText)
        {
            var input = new Input(inputText);
            foreach (var number in input.NumberSequence)
            {
                foreach (var board in input.Boards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (board.Lines[i][j] == number)
                            {
                                board.Lines[i][j] = 0;
                                board.Lines[j + 5][i] = 0;

                                if (board.Lines[i].Sum() == 0 || board.Lines[j + 5].Sum() == 0)
                                {
                                    return (board.Lines.Take(5).SelectMany(x => x).Sum() * number).ToString();
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }

        public override string GetSecondResult(string inputText)
        {
            var input = new Input(inputText);
            foreach (var number in input.NumberSequence)
            {
                foreach (var board in input.Boards)
                {
                    if (board.HasWon)
                        continue;

                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (board.Lines[i][j] == number)
                            {
                                board.Lines[i][j] = 0;
                                board.Lines[j + 5][i] = 0;

                                if (board.Lines[i].Sum() == 0 || board.Lines[j + 5].Sum() == 0)
                                {
                                    board.HasWon = true;

                                    if (input.Boards.All(x => x.HasWon))
                                        return (board.Lines.Take(5).SelectMany(x => x).Sum() * number).ToString();
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }
    }
}
