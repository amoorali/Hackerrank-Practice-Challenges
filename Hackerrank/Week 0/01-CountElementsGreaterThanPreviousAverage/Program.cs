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
     * Complete the 'countResponseTimeRegressions' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY responseTimes as parameter.
     */

    public static int countResponseTimeRegressions(List<int> responseTimes)
    {
        float average = 0;
        int result = 0;
        for (int i = 1; i < responseTimes.Count; i++)
        {
            float sum = 0;
            int count = 0;
            for (int j = 0; j < i; j++)
            {
                sum += responseTimes[j];
                count++;
            }
            average = sum / count;
            if (responseTimes[i] > average)
                result++;
        }
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int responseTimesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> responseTimes = new List<int>();

        for (int i = 0; i < responseTimesCount; i++)
        {
            int responseTimesItem = Convert.ToInt32(Console.ReadLine().Trim());
            responseTimes.Add(responseTimesItem);
        }

        int result = Result.countResponseTimeRegressions(responseTimes);

        Console.WriteLine(result);
    }
}
