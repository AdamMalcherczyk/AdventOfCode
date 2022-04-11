using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day18
{
    internal class Number
    {
        public List<Pair> Pairs { get; set; } = new List<Pair>();
    }

    public class Pair
    {
        public int Value { get; set; }
        public Pair Left { get; set; }
        public Pair Right { get; set; }
        public int NestLevel { get; set; }
    }

    internal class Snailfish : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            return "";
        }

        internal override string GetSecondResult(string inputText)
        {
            return "";
        }

        internal Number Parse(string input)
        {
            var result = new Number();
            int nestLevel = -1;
            int tempNumber = 0;
            Pair tempPair = new Pair();
            bool addPair = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[')
                {
                    nestLevel++;
                    addPair = true;
                }
                else if (input[i] == ']')
                {
                    if (addPair)
                    {
                        tempPair.Right = new Pair();
                        tempPair.Right.Value = tempNumber;
                        tempPair.NestLevel = nestLevel;
                        result.Pairs.Add(tempPair);
                        tempPair = new Pair();
                        tempNumber = 0;
                        addPair = false;
                    }
                    nestLevel--;
                }

                else if (Char.IsNumber(input[i]))
                {
                    if (tempNumber == 0)
                        tempNumber = input[i] - '0';
                    else
                        tempNumber = tempNumber * 10 + input[i] - '0';
                }

                else if (input[i] == ',')
                {
                    tempPair.Left = new Pair();
                    tempPair.Left.Value = tempNumber;
                    tempNumber = 0;
                    addPair = true;
                }
            }

            return result;
        }
    }
}

