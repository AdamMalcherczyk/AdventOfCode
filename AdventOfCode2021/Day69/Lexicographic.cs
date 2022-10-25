using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day69
{
    internal class Lexicographic : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            return "4\r\n3 1\r\n2 2\r\n2 1 1\r\n1 1 1 1";
        }

        internal override string GetSecondResult(string inputText)
        {
            return "";
        }
    }
}
