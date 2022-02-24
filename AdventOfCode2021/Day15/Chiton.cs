using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day15
{
    internal class Chiton : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            var rows = inputText.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var risks = rows.Select(x => x.ToCharArray()).Select(x => x.Select(y => y - '0').ToArray()).ToArray();
            long[,] totals = new long[risks.Length, rows[0].Length];

            Calculate(totals, risks);

            return totals[totals.GetLength(0) - 1, totals.GetLength(1) - 1].ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            var rows = inputText.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var risks = rows.Select(x => x.ToCharArray()).Select(x => x.Select(y => y - '0').ToArray()).ToArray();
            var totals = new long[rows.Length * 5, rows[0].Length * 5];

            Calculate(totals, risks);

            return totals[totals.GetLength(0) - 1, totals.GetLength(1) - 1].ToString();
        }

        private void Calculate(long[,] totals, int[][] risks)
        {
            for (int i = 0; i < totals.GetLength(0); i++)
            {
                for (int j = 0; j < totals.GetLength(1); j++)
                {
                    int curentRisk = RecalulateRisk(risks, i, j);

                    if (i > 0 && j > 0)
                    {
                        totals[i, j] = Math.Min(totals[i - 1, j], totals[i, j - 1]) + curentRisk;
                    }
                    else if (i > 0)
                    {
                        totals[i, j] = totals[i - 1, j] + curentRisk;
                    }
                    else if (j > 0)
                    {
                        totals[i, j] = totals[i, j - 1] + curentRisk;
                    }
                    else
                    {
                        totals[i, j] = 0;
                    }

                    ReCalculateTotalRisksRecursivly(totals[i, j], i, j, totals, risks, 0);
                }
            }
        }

        private void ReCalculateTotalRisksRecursivly(long totalSum, int x, int y, long[,] totals, int[][] risks, int depth)
        {
            if (depth > 15)
                return;

            if (totals[x, y] < totalSum)
                return;
            else
                totals[x, y] = totalSum;

            if (x > 0)
                ReCalculateTotalRisksRecursivly(totals[x, y] + RecalulateRisk(risks, x - 1, y), x - 1, y, totals, risks, depth + 1);
            if (y > 0)
                ReCalculateTotalRisksRecursivly(totals[x, y] + RecalulateRisk(risks, x, y - 1), x, y - 1, totals, risks, depth + 1);
            if (x < totals.GetLength(0) - 1)
                ReCalculateTotalRisksRecursivly(totals[x, y] + RecalulateRisk(risks, x + 1, y), x + 1, y, totals, risks, depth + 1);
            if (y < totals.GetLength(1) - 1)
                ReCalculateTotalRisksRecursivly(totals[x, y] + RecalulateRisk(risks, x, y + 1), x, y + 1, totals, risks, depth + 1);
        }

        private static int RecalulateRisk(int[][] risks, int x, int y)
        {
            int tempRisk = (risks[x % risks.Length][y % risks[0].Length] + x / risks.Length + y / risks[0].Length);
            int curentRisk = tempRisk > 9 ? tempRisk - 9 : tempRisk;
            return curentRisk;
        }
    }
}

