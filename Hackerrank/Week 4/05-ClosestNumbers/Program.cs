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
     * Complete the 'closestNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> ClosestNumbers(List<int> arr)
    {
        var differenceFrequency = new Dictionary<long, List<List<int>>>();
        var result = new List<int>();

        arr.Sort();

        for (int i = 1; i < arr.Count; i++)
        {
            int firstNumber = arr[i - 1];
            int secondNumber = arr[i];
            long difference = secondNumber - firstNumber;
            var pair = new List<int> { firstNumber, secondNumber };

            if (differenceFrequency.ContainsKey(difference))
                differenceFrequency[difference].Add(pair);
            else
                differenceFrequency[difference] = new List<List<int>>() { pair };
        }

        var minDifference = differenceFrequency.MinBy(c => c.Key).Key;

        differenceFrequency[minDifference].ForEach(c => result.AddRange(c));

        return result;
    }

    public static List<int> closestNumbers(List<int> arr)
    {
        var result = new List<int>();
        var minDifference = long.MaxValue;

        arr.Sort();

        for (int i = 1; i < arr.Count; i++)
        {
            var firstNumber = arr[i - 1];
            var secondNumber = arr[i];
            long difference = secondNumber - firstNumber;

            if (difference < minDifference)
            {
                minDifference = difference;
                result.Clear();
                result.Add(firstNumber);
                result.Add(secondNumber);
            }
            else if (difference == minDifference)
            {

                result.Add(firstNumber);
                result.Add(secondNumber);
            }
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.closestNumbers(arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
