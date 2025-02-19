
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> votes = new Dictionary<string, int>();

        votes["Alice"] = 3;
        votes["Bob"] = 5;
        votes["Charlie"] = 2;

        SortedDictionary<string, int> sortedVotes = new SortedDictionary<string, int>(votes);

        foreach (var vote in sortedVotes)
        {
            Console.WriteLine($"{vote.Key}: {vote.Value}");
        }
    }
}

