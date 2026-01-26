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
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */
    public static bool IsMagic(int[][] matrix)
    {
        const int magicNumber = 15;

        var sums = matrix
            .Select((r => r.Sum()))
            .Concat(Enumerable.Range(0, 3)
                .Select(c => matrix.Sum(r => r[c])))
            .Concat(
            [
                matrix[0][0] + matrix[1][1] + matrix[2][2],
                matrix[0][2] + matrix[1][1] + matrix[2][0]
            ]);

        return sums.All(s => s == magicNumber);
    }

    static IEnumerable<int[]> GetPermutations(int[] arr, int start)
    {
        if (start == arr.Length - 1)
        {
            yield return (int[])arr.Clone();
            yield break;
        }

        for (int i = start; i < arr.Length; i++)
        {
            (arr[start], arr[i]) = (arr[i], arr[start]);
            foreach (var p in GetPermutations(arr, start + 1))
                yield return p;
            (arr[start], arr[i]) = (arr[i], arr[start]);
        }
    }

    public static int FormingMagicSquare(List<List<int>> s)
    {
        var magicSquares = new List<int[][]>();

        foreach (var perm in GetPermutations([.. Enumerable.Range(1, 9)], 0))
        {
            var square = new int[][]
            {
                [.. perm.Take(3)],
                [.. perm.Skip(3).Take(3)],
                [.. perm.Skip(6).Take(3)]
            };

            if (IsMagic(square))
                magicSquares.Add(square);
        }

        int minCost = int.MaxValue;

        foreach (var square in magicSquares)
        {
            int cost = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    cost += Math.Abs(s[i][j] - square[i][j]);

            minCost = Math.Min(minCost, cost);
        }

        return minCost;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.FormingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
