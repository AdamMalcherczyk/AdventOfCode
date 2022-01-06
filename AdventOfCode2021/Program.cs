using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AdventOfCode2021Tests")]

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            bool wrongInputTryAgain = true;
            int day = 0;

            while (wrongInputTryAgain)
            {
                Console.WriteLine("Choose day (0 to exit): ");

                var dayInput = Console.ReadLine();
                
                if (wrongInputTryAgain = (int.TryParse(dayInput, out day) == false || day > 25 || day <= 0))
                {
                    if (day == 0)
                        return;

                    Console.WriteLine("Incorrect input, expected <1,25>");
                }
            }
            
            var childTypes = Assembly.GetAssembly(typeof(Base)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Base)));

            var concrteClass = childTypes.FirstOrDefault(x => x.Namespace == $"AdventOfCode2021.Day{day:00}");

            if (concrteClass == null)
            {
                Console.WriteLine("No solution for this day yet.");
                return;
            }

            var instance = (Base)Activator.CreateInstance(concrteClass);

            Console.WriteLine($"First part result: {Environment.NewLine}{instance.GetFirstResult()}{Environment.NewLine}");
            Console.WriteLine($"Second part result: {Environment.NewLine}{instance.GetSecondResult()}{Environment.NewLine}");
        }
    }
}
