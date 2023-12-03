using AdventOfCode;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AdventOfCode2022Tests")]

bool wrongInputTryAgain = true;
int day = 0;

do
{
    Console.WriteLine("Choose day (0 to exit): ");

    var dayInput = Console.ReadLine();

    if (wrongInputTryAgain = (int.TryParse(dayInput, out day) == false || day > 25 || day <= 0))
    {
        if (day == 0)
            return;

        Console.WriteLine("Incorrect input, expected <1,25>");
    }
} while (wrongInputTryAgain);

var childTypes = Assembly.Load($"AdventOfCode2022").GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Base)));

var concrteClass = childTypes.FirstOrDefault(x => x.Namespace == $"AdventOfCode2022.Day{day:00}");

if (concrteClass == null)
{
    Console.WriteLine("No solution for this day yet.");
    return;
}

var instance = (Base)Activator.CreateInstance(concrteClass)!;

Console.WriteLine($"First part result: {Environment.NewLine}{instance.GetFirstResult()}{Environment.NewLine}");
Console.WriteLine($"Second part result: {Environment.NewLine}{instance.GetSecondResult()}{Environment.NewLine}");