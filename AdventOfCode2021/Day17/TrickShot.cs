using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day17
{
    internal class TrickShot : Base
    {
        internal override string GetFirstResult(string inputText)
        {
            var yRange = inputText.Split(":")[1].Split(",")[1].Split("=")[1].Split("..");
            var yMin = int.Parse(yRange[0]);
            var yMax = int.Parse(yRange[1]);

            // so we can ignore x for first day, coz it's heading to 0, and stops increasing/decreasing
            // what we care about is y
            // max height of y is simply (n*(n+1))/2
            // no matter what is the initial velocity going upword, we will always end up at 0 height at some point (for positive initial velocity)
            // so what we care about is what velocity we have already build up going downwords
            // if we started with 100 initial velocity we will have 100 velocity going downword so after passing height 0 again next step is -101, next -203 etc.
            // in conclusion what we care about is yMin, and initial velocity is suppose to be abs(yMin)-1
            // ofcourse I simplified it a little, but its true when looking at the whole problem

            var initialVelocity = Math.Abs(yMin) - 1;
            return ((initialVelocity* (initialVelocity+1))/2).ToString();
        }

        internal class PossibleInitialSpeed
        {
            public int Value { get; set; }
            public int Iteration { get; set; }
            public bool Landed { get; set; }

            public PossibleInitialSpeed(int value, int iteration, bool landed)
            {
                Value = value;
                Iteration = iteration;
                Landed = landed;
            }
        }

        internal class InitialVelocity
        {
            public int XVelocity { get; set; }
            public int YVelocity { get; set; }

            public InitialVelocity(int xVelocity, int yVelocity)
            {
                XVelocity = xVelocity;
                YVelocity = yVelocity;
            }

            public override bool Equals(object obj)
            {
                if(obj is InitialVelocity comparer)
                {
                    return XVelocity == comparer.XVelocity && YVelocity == comparer.YVelocity;
                }

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(XVelocity, YVelocity);
            }
        }

        internal override string GetSecondResult(string inputText)
        {
            var xRange = inputText.Split(":")[1].Split(",")[0].Split("=")[1].Split("..");
            var xMin = int.Parse(xRange[0]);
            var xMax = int.Parse(xRange[1]);

            var yRange = inputText.Split(":")[1].Split(",")[1].Split("=")[1].Split("..");
            var yMin = int.Parse(yRange[0]);
            var yMax = int.Parse(yRange[1]);

            // so we need to get every initial velocity
            // there are couple types of shots
            // most basic one is just setting intial velocity in that way, so it will one in one shot
            // for above example we have (xMax-xMin)*(yMax-yMin) that kind of shots
            // after that what we care about is every other shot that will have final xVelocity != 0 
            // those kind of shots have set number of steps that yVeloctiy has to carter to

            /* new approach max up is Math.Abs(yMin) - 1, max down is yMin
             when it comes to x-es we can go from max = xMax down to some value that will go inside > xMin
             minimum X for 20 is 6

            better example would be to get all values of X that will land inside, and only iterate by those
            even better get all values of X that will land, and number of iterations for them to land
            so let's start from getting all X initial speeds and their number of iterations
             */

            //note to self, some initial velocities can have more than one landing points for trick shot to work
            // for example 20..30 -> initial X speed = 7
            // 7 -> 13 -> 18 -> 22 -> 25 -> 27 -> 28 -> 28 -> 28 -> 28 .....


            /* I am starting to think that it's better to look at X and Y separetly, and just match number of iterations that work for shot
             so we will get all X and Y inital speeds that work 
             result will be calculated just by matching number of iterations of X and Y 
            
            for example if there are 3 X initial speed that would land inside in 2 iterations and 3 Y that also need 2 iterations, we would multiply them to get 6 shots
             */

            var xSpeeds = new List<PossibleInitialSpeed>();

            for (int i = 1; i <= xMax; i++)
            {
                int currentX = 0;
                var tempPossibilities = new List<PossibleInitialSpeed>();

                for (int j = i; j >= 0; j--)
                {
                    currentX += j;

                    if (currentX > xMax)
                        break;

                    if(currentX >= xMin)
                    {
                        int iterations = i - j + 1;
                        int initialXSpeed = i;

                        tempPossibilities.Add(new PossibleInitialSpeed(initialXSpeed, iterations, false));

                        if (j == 0)
                        {
                            xSpeeds.Add(new PossibleInitialSpeed(initialXSpeed, tempPossibilities.First().Iteration, true));
                            tempPossibilities.Clear();
                            break;
                        }
                    }
                }

                xSpeeds.AddRange(tempPossibilities);
            }

            var ySpeeds = new List<PossibleInitialSpeed>();

            //max up is Math.Abs(yMin) - 1, max down is yMin
            for (int i = yMin; i <= Math.Abs(yMin) - 1; i++)
            {
                int currentY = 0;
                int iteration = 0;
                int velocity = i;
                while(currentY >= yMin)
                {
                    iteration++;
                    currentY += velocity--;

                    if(currentY >= yMin && currentY <= yMax)
                    {
                        ySpeeds.Add(new PossibleInitialSpeed(i, iteration, false));
                    }
                }
            }

            var initialVelocities = xSpeeds.Where(x => x.Landed == false).GroupJoin(ySpeeds, x => x.Iteration, y => y.Iteration, GroupJoinResultSelection).SelectMany(x => x);
            foreach (var xSpeed in xSpeeds.Where(x => x.Landed))
            {
                initialVelocities = initialVelocities.Union(ySpeeds.Where(x => x.Iteration >= xSpeed.Iteration).Select(x => new InitialVelocity(xSpeed.Value, x.Value)));
            }

            // we are only looking for distinct initialSpeeds, so we need to filter copies
            initialVelocities = initialVelocities.Distinct();

            return initialVelocities.Count().ToString();
        }

        private List<InitialVelocity> GroupJoinResultSelection(PossibleInitialSpeed xSpeed, IEnumerable<object> ySpeeds)
        {
            var result = new List<InitialVelocity>();
            foreach (PossibleInitialSpeed ySpeed in ySpeeds)
            {
                result.Add(new InitialVelocity(xSpeed.Value, ySpeed.Value));
            }
            return result;
        }
    }
}

