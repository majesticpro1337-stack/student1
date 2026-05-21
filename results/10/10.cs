using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    public static int sockMerchant(int n, List<int> ar)
    {
        HashSet<int> socks = new HashSet<int>();
        int pairs = 0;

        foreach (int sock in ar)
        {
            if (socks.Contains(sock))
            {
                socks.Remove(sock);
                pairs++;
            }
            else
            {
                socks.Add(sock);
            }
        }

        return pairs;
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().Trim().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = sockMerchant(n, ar);

        Console.WriteLine(result);
    }
}
