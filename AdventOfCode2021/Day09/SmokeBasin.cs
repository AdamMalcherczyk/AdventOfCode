using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day09
{
    internal class SmokeBasin : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            var rows = inputText.Split("\r\n");
            int[,] hackedField = new int[rows.Length + 2, rows[0].Length + 2];
            InitializeField(rows, hackedField);

            List<int> lowPoints = new List<int>();

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[0].Length; j++)
                {
                    var current = hackedField[i + 1, j + 1];
                    if (current < hackedField[i + 1, j + 2] && current < hackedField[i + 1, j] && current < hackedField[i, j + 1] && current < hackedField[i + 2, j + 1])
                    {
                        lowPoints.Add(current);
                    }
                }
            }

            return (lowPoints.Sum() + lowPoints.Count()).ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            var rows = inputText.Split("\r\n");
            int[,] hackedField = new int[rows.Length + 2, rows[0].Length + 2];
            InitializeField(rows, hackedField);

            List<int> basinSizes = new List<int>();

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[0].Length; j++)
                {
                    var current = hackedField[i + 1, j + 1];
                    if (current < hackedField[i + 1, j + 2] && current < hackedField[i + 1, j] && current < hackedField[i, j + 1] && current < hackedField[i + 2, j + 1])
                    {
                        basinSizes.Add(GetBasinSizeRecursivly(hackedField, i + 1, j + 1));
                    }
                }
            }

            var maxSize = basinSizes.Max();
            basinSizes.Remove(basinSizes.Find(x => x == maxSize));
            var secondMaxSize = basinSizes.Max();
            basinSizes.Remove(basinSizes.Find(x => x == secondMaxSize));

            return (maxSize * secondMaxSize * basinSizes.Max()).ToString();
        }

        private static void InitializeField(string[] rows, int[,] hackedField)
        {
            for (int i = 0; i < rows[0].Length + 2; i++)
            {
                hackedField[0, i] = 9;
                hackedField[rows.Length + 1, i] = 9;
            }
            for (int i = 0; i < rows.Length + 2; i++)
            {
                hackedField[i, 0] = 9;
                hackedField[i, rows[0].Length + 1] = 9;
                if (i != 0 && i != rows.Length + 1)
                {
                    var row = rows[i - 1].Select(x => x - '0').ToArray();
                    for (int j = 0; j < rows[0].Length; j++)
                    {
                        hackedField[i, j + 1] = row[j];
                    }
                }
            }
        }

        private int GetBasinSizeRecursivly(int[,] hackedField, int x, int y)
        {
            if (hackedField[x, y] is -1 or 9)
                return 0;

            hackedField[x, y] = -1;

            return GetBasinSizeRecursivly(hackedField, x - 1, y) + GetBasinSizeRecursivly(hackedField, x + 1, y) + GetBasinSizeRecursivly(hackedField, x, y + 1) + GetBasinSizeRecursivly(hackedField, x, y - 1) + 1;
        }
    }
}
