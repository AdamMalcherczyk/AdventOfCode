using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05
{
    internal class HydrothermalVenture : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            var lines = inputText.Split("\r\n");
            var board = new Dictionary<(int, int), int>();
            foreach (var line in lines)
            {
                var points = line.Split(" -> ").Select(x => (int.Parse(x.Split(",")[0]), int.Parse(x.Split(",")[1]))).OrderBy(x => x.Item1).OrderBy(x => x.Item2);
                var startPoint = points.First();
                var endPoint = points.Last();
                if (startPoint.Item1 == endPoint.Item1)
                {
                    for (int i = startPoint.Item2; i <= endPoint.Item2; i++)
                    {
                        var key = (startPoint.Item1, i);
                        if (board.ContainsKey(key))
                            board[key]++;
                        else
                            board.Add(key, 1);
                    }
                }
                else if (startPoint.Item2 == endPoint.Item2)
                {
                    for (int i = startPoint.Item1; i <= endPoint.Item1; i++)
                    {
                        var key = (i, startPoint.Item2);
                        if (board.ContainsKey(key))
                            board[key]++;
                        else
                            board.Add(key, 1);
                    }
                }
            }

            return board.Values.Count(x => x > 1).ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            var lines = inputText.Split("\r\n");
            var board = new Dictionary<(int, int), int>();
            foreach (var line in lines)
            {
                var points = line.Split(" -> ").Select(x => (int.Parse(x.Split(",")[0]), int.Parse(x.Split(",")[1]))).OrderBy(x => x.Item1).ThenBy(x => x.Item2);
                var startPoint = points.First();
                var endPoint = points.Last();
                if (startPoint.Item1 == endPoint.Item1)
                {
                    for (int i = startPoint.Item2; i <= endPoint.Item2; i++)
                    {
                        var key = (startPoint.Item1, i);
                        if (board.ContainsKey(key))
                            board[key]++;
                        else
                            board.Add(key, 1);
                    }
                }
                else if (startPoint.Item2 == endPoint.Item2)
                {
                    for (int i = startPoint.Item1; i <= endPoint.Item1; i++)
                    {
                        var key = (i, startPoint.Item2);
                        if (board.ContainsKey(key))
                            board[key]++;
                        else
                            board.Add(key, 1);
                    }
                }
                else if (Math.Abs(startPoint.Item1 - endPoint.Item1) == Math.Abs(startPoint.Item2 - endPoint.Item2))
                {
                    int numberOfDiagPoints = Math.Abs(startPoint.Item1 - endPoint.Item1);
                    int item1Diff = 1;
                    int item2Diff = startPoint.Item2 > endPoint.Item2 ? -1 : 1;
                    for (int i = 0; i <= numberOfDiagPoints; i++)
                    {
                        var key = startPoint;
                        key.Item1 += item1Diff * i;
                        key.Item2 += item2Diff * i;
                        if (board.ContainsKey(key))
                            board[key]++;
                        else
                            board.Add(key, 1);
                    }
                }
            }

            return board.Values.Count(x => x > 1).ToString();
        }
    }
}
