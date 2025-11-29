using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var t = Int32.Parse(Console.ReadLine());
        var n = Int32.Parse(Console.ReadLine());
        var mid = (n - 1) / 2;
        var numbers = new int[n];

        for (int testCase = 0; testCase < t; testCase++)
        {
            numbers = Array.ConvertAll(Console.ReadLine().Split(), Int32.Parse);

            Array.Sort(numbers);

            var left = mid;
            var right = n - 1;

            // reverse the second half
            while (left <= right)
            {
                numbers.SwapValues(left, right);
                left++;
                right--;
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}

public static class ArrayExtensions
{
    public static void SwapValues<T>(this T[] source, int firstIndex, int secondIndex)
    {
        var temp = source[firstIndex];
        source[firstIndex] = source[secondIndex];
        source[secondIndex] = temp;
    }
}
