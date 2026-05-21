using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public static int diagonalDifference(List<List<int>> arr)
    {
        int primaryDiagonalSum = 0;
        int secondaryDiagonalSum = 0;
        int n = arr.Count;

        for (int i = 0; i < n; i++)
        {
            primaryDiagonalSum += arr[i][i];
            secondaryDiagonalSum += arr[i][n - 1 - i];
        }

        return Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine()!.Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine()!.Trim().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = diagonalDifference(arr);

        Console.WriteLine(result);
    }
}
