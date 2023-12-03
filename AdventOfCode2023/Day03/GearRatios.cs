using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day03
{
    internal class GearRatios : Base
    {
        class Symbol
        {
            public Symbol(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }

            public List<Number> Numbers { get; set; } = new List<Number>();
            public bool IsValidSymbol => Numbers.Count == 2;
            public int SymbolValue => Numbers[0].Value * Numbers[1].Value;
        }

        class Number
        {
            private int _value;

            public Number(int value, int x, int y)
            {
                X = x;
                Y = y;
                Value = value;
            }


            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get => _value; set { _value = value; Length++; } }
            public int Length { get; set; }
        }

        public override string GetFirstResult(string inputText)
        {
            int result = 0;
            var input = inputText.Split("\r\n");
            List<Number> numbers = new List<Number>();
            Number currentNumber = null;
            List<Symbol> symbols = new List<Symbol>();

            for (int i = 0; i < input.Length; i++)
            {
                bool wasLastNumber = false;
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (char.IsNumber(input[i][j]))
                    {
                        if (wasLastNumber == false)
                        {
                            currentNumber = new Number(input[i][j] - '0', i, j);
                            numbers.Add(currentNumber);
                            wasLastNumber = true;
                            continue;
                        }

                        currentNumber.Value = (currentNumber.Value * 10) + input[i][j] - '0';
                        continue;
                    }

                    if (wasLastNumber == true)
                    {
                        wasLastNumber = false;
                    }

                    if(input[i][j] != '.')
                    {
                        symbols.Add(new Symbol(i,j));
                    }
                }
            }

            foreach (var number in numbers)
            {
                var possibleSymbols = symbols.Where(x => x.X >= number.X - 1 && x.X <= number.X + 1);

                if (possibleSymbols.Any(x => x.Y >= number.Y - 1 && x.Y <= number.Y + number.Length))
                    result += number.Value;
            }

            // each number has a row, a start column and length
            // each symbol has a row and column
            // let's just get all the data listed above

            return result.ToString();
        }

        public override string GetSecondResult(string inputText)
        {
            int result = 0;
            var input = inputText.Split("\r\n");
            List<Number> numbers = new List<Number>();
            Number currentNumber = null;
            List<Symbol> symbols = new List<Symbol>();

            for (int i = 0; i < input.Length; i++)
            {
                bool wasLastNumber = false;
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (char.IsNumber(input[i][j]))
                    {
                        if (wasLastNumber == false)
                        {
                            currentNumber = new Number(input[i][j] - '0', i, j);
                            numbers.Add(currentNumber);
                            wasLastNumber = true;
                            continue;
                        }

                        currentNumber.Value = (currentNumber.Value * 10) + input[i][j] - '0';
                        continue;
                    }

                    if (wasLastNumber == true)
                    {
                        wasLastNumber = false;
                    }

                    if (input[i][j] == '*')
                    {
                        symbols.Add(new Symbol(i, j));
                    }
                }
            }

            foreach (var number in numbers)
            {
                var validSymbols = symbols.Where(x => x.X >= number.X - 1 && x.X <= number.X + 1)
                    .Where(x => x.Y >= number.Y - 1 && x.Y <= number.Y + number.Length);

                foreach (var validSymbol in validSymbols)
                {
                    validSymbol.Numbers.Add(number);
                }
            }

            result = symbols.Where(x => x.IsValidSymbol).Sum(x => x.SymbolValue);

            return result.ToString();
        }
    }
}
