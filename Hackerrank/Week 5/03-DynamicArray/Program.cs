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
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

    public enum Operation
    {
        First = 1,
        Second = 2
    }

    public static List<int> dynamicArray(int n, List<List<int>> queries)
    {
        List<List<int>> arr = new List<List<int>>(n);

        for (int i = 0; i < n; i++)
            arr.Add(new List<int>());

        List<int> answers = new List<int>();
        int lastAnswer = 0;

        foreach (var query in queries)
        {
            var operation = (Operation)query[0];
            var firstNumber = query[1];
            var secondNumber = query[2];

            if (operation == Operation.First)
            {
                FirstOperation(arr, n, lastAnswer, firstNumber, secondNumber);
                Console.WriteLine(arr.Count());
            }
            else
                SecondOperation(arr, answers, n, ref lastAnswer, firstNumber, secondNumber);
        }

        return answers;
    }

    public static int FormulaCalculation(int n, int lastAnswer, int x)
    {
        return ((x ^ lastAnswer) % n);
    }

    public static void FirstOperation(List<List<int>> arr, int n, int lastAnswer, int x, int y)
    {
        var idx = FormulaCalculation(n, lastAnswer, x);

        arr[idx].Add(y);
    }

    public static void SecondOperation(List<List<int>> arr, List<int> answers, int n, ref int lastAnswer, int x, int y)
    {
        var idx = FormulaCalculation(n, lastAnswer, x);

        lastAnswer = arr[idx][y % arr[idx].Count];
        answers.Add(lastAnswer);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = Result.dynamicArray(n, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
