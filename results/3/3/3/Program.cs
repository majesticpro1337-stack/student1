using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    public static int simpleArraySum(List<int> ar)
    {
        return ar.Sum();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int arCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().Trim().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.simpleArraySum(ar);

        Console.WriteLine(result);
    }
}