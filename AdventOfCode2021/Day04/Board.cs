using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04
{
    public class Board
    {
        public int[][] Lines { get; set; }

        public bool HasWon { get; set; } = false;

        public Board(string board)
        {
            var rows = board.Split("\r\n")
                .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(y => int.Parse(y))
                    .ToArray())
                .ToArray();
            var columns = Enumerable.Range(0, 5).Select(x => Enumerable.Range(0, 5).Select(y => rows[y][x]).ToArray()).ToArray();
            Lines = rows.Concat(columns).ToArray();
        }
    }
}
