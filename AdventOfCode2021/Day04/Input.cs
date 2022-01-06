using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04
{
    public class Input
    {
        public List<int> NumberSequence { get; set; }

        public List<Board> Boards { get; set; }

        public Input(string inputText)
        {
            var splitted = inputText.Split("\r\n\r\n");
            NumberSequence = splitted[0].Split(',').Select(x => int.Parse(x)).ToList();
            Boards = splitted.Skip(1).Select(x => new Board(x)).ToList();
        }
    }
}
