using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day10
{
    internal class SyntaxScoring : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            Dictionary<char, int> corrupted = new Dictionary<char, int>() { { ')', 0 }, { '>', 0 }, { ']', 0 }, { '}', 0 } };
            foreach (var line in inputText.Split("\r\n"))
            {
                var stack = new Stack<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] is '(' or '<' or '[' or '{') { 
                        stack.Push(line[i]);
                        continue;
                    }

                    var expected = stack.Pop();
                    if (expected != Convert.ToChar(line[i] - 1) && expected != Convert.ToChar(line[i] - 2))
                    {
                        corrupted[line[i]]++;
                        break;
                    }
                }
            }
            return (corrupted[')'] * 3 + corrupted[']'] * 57 + corrupted['}'] * 1197 + corrupted['>'] * 25137).ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            return "";
        }
    }
}

