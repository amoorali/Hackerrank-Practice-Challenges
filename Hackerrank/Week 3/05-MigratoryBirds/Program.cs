using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {
        var frequency = new Dictionary<int, int>();
        arr.Sort();

        foreach (int birdType in arr)
        {
            if (frequency.ContainsKey(birdType))
                frequency[birdType]++;
            else
                frequency[birdType] = 1;
        }

        var mostFrequent = frequency.MaxBy(p => p.Value).Key;

        return mostFrequent;
    }

    public static int MigratoryBirds(List<int> arr)
    {
        var mostFrequentType = 0;
        var mostFrequentCount = 0;

        arr.GroupBy(n => n)
            .ToList()
            .ForEach(g =>
                {
                    int birdCount = g.ToList().Count;
                    int birdType = g.First();
                    Console.WriteLine(birdCount);

                    if (birdCount > mostFrequentCount)
                    {
                        mostFrequentCount = birdCount;
                        mostFrequentType = birdType;
                    }
                    if (birdCount == mostFrequentCount)
                        mostFrequentType = birdType < mostFrequentType ? birdType : mostFrequentType;
                }
            );

        return mostFrequentType;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
