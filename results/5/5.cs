using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
    {
        int appleCount = 0;
        int orangeCount = 0;

        foreach (int apple in apples)
        {
            int position = a + apple;
            if (position >= s && position <= t)
            {
                appleCount++;
            }
        }

        foreach (int orange in oranges)
        {
            int position = b + orange;
            if (position >= s && position <= t)
            {
                orangeCount++;
            }
        }

        Console.WriteLine(appleCount);
        Console.WriteLine(orangeCount);
    }

    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().Trim().Split(' ');
        int s = Convert.ToInt32(firstMultipleInput[0]);
        int t = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().Trim().Split(' ');
        int a = Convert.ToInt32(secondMultipleInput[0]);
        int b = Convert.ToInt32(secondMultipleInput[1]);

        string[] thirdMultipleInput = Console.ReadLine().Trim().Split(' ');
        int m = Convert.ToInt32(thirdMultipleInput[0]);
        int n = Convert.ToInt32(thirdMultipleInput[1]);

        List<int> apples = Console.ReadLine().Trim().Split(' ').ToList().Select(applesTemp => Convert.ToInt32(applesTemp)).ToList();
        List<int> oranges = Console.ReadLine().Trim().Split(' ').ToList().Select(orangesTemp => Convert.ToInt32(orangesTemp)).ToList();

        countApplesAndOranges(s, t, a, b, apples, oranges);
    }
}
