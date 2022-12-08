namespace AdventOfCode
{
    public abstract class Base
    {
        public virtual string GetFirstResult()
        {
            var derivedNamespace = this.GetType().Namespace!;
            var folder = derivedNamespace.Substring(derivedNamespace.IndexOf('.') + 1);
            var input = File.ReadAllText($".\\{folder}\\Input.txt");
            return GetFirstResult(input);
        }

        public abstract string GetFirstResult(string inputText);

        public virtual string GetSecondResult()
        {
            var derivedNamespace = this.GetType().Namespace!;
            var folder = derivedNamespace.Substring(derivedNamespace.IndexOf('.') + 1);
            var input = File.ReadAllText($".\\{folder}\\Input.txt");
            return GetSecondResult(input);
        }

        public abstract string GetSecondResult(string inputText);
    }
}