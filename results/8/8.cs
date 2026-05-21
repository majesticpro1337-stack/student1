using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public static List<int> breakingRecords(List<int> scores)
    {
        int maxRecord = scores[0];
        int minRecord = scores[0];
        
        int maxCount = 0;
        int minCount = 0;

        for (int i = 1; i < scores.Count; i++)
        {
            if (scores[i] > maxRecord)
            {
                maxRecord = scores[i];
                maxCount++;
            }
            else if (scores[i] < minRecord)
            {
                minRecord = scores[i];
                minCount++;
            }
        }

        return new List<int> { maxCount, minCount };
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine()!.Trim());

        List<int> scores = Console.ReadLine()!.Trim().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

        List<int> result = breakingRecords(scores);

        Console.WriteLine(String.Join(" ", result));
    }
}
