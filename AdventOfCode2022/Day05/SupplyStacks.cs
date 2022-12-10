using AdventOfCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day05
{
    internal class SupplyStacks : Base
    {
        public override string GetFirstResult(string inputText)
        {
            var inputs = inputText.Split("\r\n\r\n");
            var rawStack = inputs[0].Split("\r\n");
            inputs = inputs[1].Split("\r\n");

            Stack<char>[] stacks = new Stack<char>[(rawStack[0].Length+1)/4];
            foreach (var stackLine in rawStack.Take(rawStack.Length-1))
            {
                for (int i = 0; i < (stackLine.Length+1) / 4; i++)
                {
                    if (stackLine[i * 4 + 1] == ' ')
                        continue;

                    if (stacks[i] == null)
                        stacks[i] = new Stack<char>();

                    stacks[i].Push(stackLine[i * 4 + 1]);
                }
            }

            // reversing stacks
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<char>(stacks[i]);
            }

            foreach (var input in inputs)
            {
                var command = input.Split(new string[] { "move ", " from ", " to " }, StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray();
                for (int i = 0; i < command[0]; i++)
                {
                    stacks[command[2] - 1].Push(stacks[command[1] - 1].Pop());
                }
            }

            string result = "";
            for (int i = 0; i < stacks.Length; i++)
            {
                result += stacks[i].Peek();
            }

            return result;
        }

        public override string GetSecondResult(string inputText)
        {
            var inputs = inputText.Split("\r\n\r\n");
            var rawStack = inputs[0].Split("\r\n");
            inputs = inputs[1].Split("\r\n");

            Stack<char>[] stacks = new Stack<char>[(rawStack[0].Length + 1) / 4];
            foreach (var stackLine in rawStack.Take(rawStack.Length - 1))
            {
                for (int i = 0; i < (stackLine.Length + 1) / 4; i++)
                {
                    if (stackLine[i * 4 + 1] == ' ')
                        continue;

                    if (stacks[i] == null)
                        stacks[i] = new Stack<char>();

                    stacks[i].Push(stackLine[i * 4 + 1]);
                }
            }

            // reversing stacks
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<char>(stacks[i]);
            }

            foreach (var input in inputs)
            {
                var command = input.Split(new string[] { "move ", " from ", " to " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                char[] popped = new char[command[0]];
                for (int i = 0; i < command[0]; i++)
                {
                    popped[i] = stacks[command[1] - 1].Pop();
                }

                stacks[command[2] - 1] = new Stack<char>(stacks[command[2] - 1].Reverse().Concat(popped.Reverse()));
            }

            string result = "";
            for (int i = 0; i < stacks.Length; i++)
            {
                result += stacks[i].Peek();
            }

            return result;
        }
    }
}
