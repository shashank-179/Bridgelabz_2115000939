using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, List<string>> InvertMap(Dictionary<string, int> map)
    {
        Dictionary<int, List<string>> inverted = new Dictionary<int, List<string>>();

        foreach (var pair in map)
        {
            if (!inverted.ContainsKey(pair.Value))
                inverted[pair.Value] = new List<string>();

            inverted[pair.Value].Add(pair.Key);
        }

        return inverted;
    }

    static void Main()
    {
        Dictionary<string, int> input = new Dictionary<string, int>
        {
            { "A", 1 }, { "B", 2 }, { "C", 1 }
        };

        Dictionary<int, List<string>> result = InvertMap(input);

        foreach (var pair in result)
        {
            Console.Write(pair.Key + "=[");
            Console.Write(string.Join(", ", pair.Value));
            Console.WriteLine("]");
        }
    }
}