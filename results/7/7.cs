using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public static int getTotalX(List<int> a, List<int> b)
    {
        int count = 0;
        
        int min = a.Max();
        int max = b.Min();

        for (int i = min; i <= max; i++)
        {
            bool isFactorOfA = true;
            foreach (int num in a)
            {
                if (i % num != 0)
                {
                    isFactorOfA = false;
                    break;
                }
            }

            if (isFactorOfA)
            {
                bool isFactorOfB = true;
                foreach (int num in b)
                {
                    if (num % i != 0)
                    {
                        isFactorOfB = false;
                        break;
                    }
                }

                if (isFactorOfB)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine()!.Trim().Split(' ');
        int n = Convert.ToInt32(firstMultipleInput[0]);
        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine()!.Trim().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        List<int> brr = Console.ReadLine()!.Trim().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = getTotalX(arr, brr);

        Console.WriteLine(total);
    }
}
