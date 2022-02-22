using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day13
{
    internal class Dot
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Dot(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Dot dot &&
                   X == dot.X &&
                   Y == dot.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    internal class Fold
    {
        public bool IsX { get; set; }

        public int Value { get; set; }

        public Fold(bool isX, int value)
        {
            IsX = isX;
            Value = value;
        }
    }


    internal class TransparentOrigami : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            IEnumerable<Fold> folds;
            HashSet<Dot> dots;
            ParseInput(inputText, out folds, out dots);

            Fold(dots, folds.First());

            return dots.Count.ToString();
        }

        internal override string GetSecondResult(string inputText)
        {
            IEnumerable<Fold> folds;
            HashSet<Dot> dots;
            ParseInput(inputText, out folds, out dots);

            foreach (var fold in folds)
            {
                Fold(dots, fold);
            }

            DisplayInDebugOutput(dots, folds);

            return dots.Count.ToString();
        }

        private static void ParseInput(string inputText, out IEnumerable<Fold> folds, out HashSet<Dot> dots)
        {
            var dotsAndFoldsRaw = inputText.Split("\r\n\r\n");
            var dotsRaw = dotsAndFoldsRaw[0];
            var foldsRaw = dotsAndFoldsRaw[1];

            folds = foldsRaw.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(" ")[2].Split("=")).Select(x => new Fold(x[0] == "x", int.Parse(x[1])));
            dots = dotsRaw.Split("\r\n").Select(x => x.Split(",")).Select(x => new Dot(int.Parse(x[0]), int.Parse(x[1]))).ToHashSet();
        }

        private void Fold(HashSet<Dot> dots, Fold fold)
        {
            if (fold.IsX)
            {
                foreach (var dot in dots.Where(x => x.X > fold.Value).ToHashSet())
                {
                    var tempX = fold.Value - (dot.X - fold.Value);
                    dots.Add(new Dot(tempX, dot.Y));
                }

                dots.RemoveWhere(x => x.X > fold.Value);
            }
            else
            {

                foreach (var dot in dots.Where(x => x.Y > fold.Value).ToHashSet())
                {
                    var tempY = fold.Value - (dot.Y - fold.Value);
                    dots.Add(new Dot(dot.X, tempY));
                }

                dots.RemoveWhere(x => x.Y > fold.Value);
            }
        }

        private void DisplayInDebugOutput(HashSet<Dot> dots, IEnumerable<Fold> folds)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < folds.Last(x => x.IsX == false).Value; i++)
            {

                for (int j = 0; j < folds.Last(x => x.IsX).Value; j++)
                {
                    if (dots.Contains(new Dot(j, i)))
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }

                sb.AppendLine();
            }

            Debug.WriteLine(sb.ToString());
        }
    }
}

