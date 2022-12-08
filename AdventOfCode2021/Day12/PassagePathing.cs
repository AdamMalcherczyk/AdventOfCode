using AdventOfCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day12
{
    //TODO change Array to Queue/Stack - more optimal
    internal class PassagePathing : Base
    {
        public override string GetFirstResult(string inputText)
        {
            var connectionsRaw = inputText.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split("-"));

            Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();

            foreach (var connection in connectionsRaw)
            {
                if(connections.ContainsKey(connection[0]) == false)
                    connections.Add(connection[0], new List<string>() { connection[1] });
                else
                    connections[connection[0]].Add(connection[1]);

                if(connections.ContainsKey(connection[1]) == false)
                    connections.Add(connection[1], new List<string>() { connection[0] });
                else
                    connections[connection[1]].Add(connection[0]);
            }

            int numberOfValidPaths = TraverseReqursively(connections, new string[] { "start" });

            return numberOfValidPaths.ToString();
        }

        private int TraverseReqursively(Dictionary<string, List<string>> connections, string[] traversed)
        {
            if (traversed.Last() == "end")
                return 1;

            int result = 0;

            foreach (var connection in connections[traversed.Last()])
            {
                if (connection.ToLower() == connection && traversed.Contains(connection))
                {
                    continue;
                }

                string[] tempTraversed = new string[traversed.Length + 1];
                Array.Copy(traversed, 0, tempTraversed, 0, traversed.Length);
                tempTraversed[traversed.Length] = connection;
                result += TraverseReqursively(connections, tempTraversed);
            }

            return result;
        }

        public override string GetSecondResult(string inputText)
        {
            var connectionsRaw = inputText.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split("-"));

            Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();

            foreach (var connection in connectionsRaw)
            {
                if (connections.ContainsKey(connection[0]) == false)
                    connections.Add(connection[0], new List<string>() { connection[1] });
                else
                    connections[connection[0]].Add(connection[1]);

                if (connections.ContainsKey(connection[1]) == false)
                    connections.Add(connection[1], new List<string>() { connection[0] });
                else
                    connections[connection[1]].Add(connection[0]);
            }

            int numberOfValidPaths = TraverseReqursively(connections, new string[] { "start" }, false);

            return numberOfValidPaths.ToString();
        }

        private int TraverseReqursively(Dictionary<string, List<string>> connections, string[] traversed, bool visitedSmallTwice)
        {
            if (traversed.Last() == "end")
            {
                //Debug.WriteLine(string.Join(",", traversed));
                return 1;
            }

            int result = 0;

            foreach (var connection in connections[traversed.Last()])
            {
                var visitedSmallTwiceTemp = visitedSmallTwice;

                if (connection == "start")
                    continue;

                if (connection.ToLower() == connection && traversed.Contains(connection))
                {
                    if (visitedSmallTwiceTemp)
                        continue;
                    visitedSmallTwiceTemp = true;
                }

                string[] tempTraversed = new string[traversed.Length + 1];
                Array.Copy(traversed, 0, tempTraversed, 0, traversed.Length);
                tempTraversed[traversed.Length] = connection;
                result += TraverseReqursively(connections, tempTraversed, visitedSmallTwiceTemp);
            }

            return result;
        }
    }
}

