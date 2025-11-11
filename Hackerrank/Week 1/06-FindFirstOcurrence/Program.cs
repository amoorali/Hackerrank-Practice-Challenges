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
     * Complete the 'findFirstOccurrence' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY nums
     *  2. INTEGER target
     */

    public static int findFirstOccurrence(List<int> nums, int target)
    {
        var left = 0;
        var right = nums.Count - 1;
        var mid = 0;

        while (left <= right)
        {
            mid = right - left / 2;
            if (target <= nums[mid])
                right = mid - 1;
            else
                left = mid + 1;
        }

        if (left < nums.Count && target == nums[left])
            return left;

        return -1;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int numsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> nums = new List<int>();

        for (int i = 0; i < numsCount; i++)
        {
            int numsItem = Convert.ToInt32(Console.ReadLine().Trim());
            nums.Add(numsItem);
        }

        int target = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.findFirstOccurrence(nums, target);

        Console.WriteLine(result);
    }
}
