using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    public static List<int> gradingStudents(List<int> grades)
    {
        List<int> roundedGrades = new List<int>();

        foreach (int grade in grades)
        {
            if (grade < 38)
            {
                roundedGrades.Add(grade);
            }
            else
            {
                int nextMultipleOfFive = ((grade / 5) + 1) * 5;

                if (nextMultipleOfFive - grade < 3)
                {
                    roundedGrades.Add(nextMultipleOfFive);
                }
                else
                {
                    roundedGrades.Add(grade);
                }
            }
        }

        return roundedGrades;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        List<int> result = Result.gradingStudents(grades);

        Console.WriteLine(String.Join("\n", result));
    }
}
