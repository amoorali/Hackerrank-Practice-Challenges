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
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

     public static int diagonalDifference1(List<List<int>> arr)
    {
        var n = arr.Count - 1;
        var m = arr[0].Count - 1;

        var leftToRight = 0;
        var rightToLeft = 0;

        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                if (i == j)
                    leftToRight += arr[i][j];

                if (i + j == m)
                    rightToLeft += arr[i][j];
            }
        }

        return Math.Abs(leftToRight - rightToLeft);
    }

    public static int diagonalDifference2(List<List<int>> arr)
    {
        var arraySize = arr.Count;
        var leftToRight = 0;
        var rightToLeft = 0;

        for (int i = 0; i < arraySize; i++)
        {
            leftToRight += arr[i][i];
            rightToLeft += arr[i][arraySize - i - 1];
        }

        return Math.Abs(leftToRight - rightToLeft);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference2(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
