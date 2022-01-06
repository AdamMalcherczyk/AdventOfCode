using System.IO;

namespace AdventOfCode2021
{
    internal abstract class Base
    {
        internal virtual string GetFirstResult()
        {
            var derivedNamespace = this.GetType().Namespace;
            var folder = derivedNamespace.Substring(derivedNamespace.IndexOf('.') + 1);
            var input = File.ReadAllText($".\\{folder}\\Input.txt");
            return GetFirstResult(input);
        }

        internal abstract string GetFirstResult(string inputText);

        internal virtual string GetSecondResult()
        {
            var derivedNamespace = this.GetType().Namespace;
            var folder = derivedNamespace.Substring(derivedNamespace.IndexOf('.') + 1);
            var input = File.ReadAllText($".\\{folder}\\Input.txt");
            return GetSecondResult(input);
        }

        internal abstract string GetSecondResult(string inputText);
    }
}