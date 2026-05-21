using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    public static int migratoryBirds(List<int> arr)
    {
        int[] birdCounts = new int[6];

        foreach (int bird in arr)
        {
            birdCounts[bird]++;
        }

        int maxCount = 0;
        int mostFrequentBird = 1;

        for (int i = 1; i <= 5; i++)
        {
            if (birdCounts[i] > maxCount)
            {
                maxCount = birdCounts[i];
                mostFrequentBird = i;
            }
        }

        return mostFrequentBird;
    }

    public static void Main(string[] args)
    {
        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().Trim().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = migratoryBirds(arr);

        Console.WriteLine(result);
    }
}
