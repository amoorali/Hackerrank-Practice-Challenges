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
     * Complete the 'maximizeNonOverlappingMeetings' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY meetings as parameter.
     */

    public static int maximizeNonOverlappingMeetings(List<List<int>> meetings)
    {
        var sorted_meetings = meetings.OrderBy(l => l[1]);

        var count = 1;
        var end = sorted_meetings.ElementAt(0).ElementAt(1);
        // Console.WriteLine(end);

        foreach (var meeting in sorted_meetings.Skip(1))
        {
            // Console.WriteLine("{0} {1}", meeting[0], meeting[1]);
            if (meeting[0] >= end)
            {
                count++;
                end = meeting[1];
            }
        }
        return count;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int meetingsRows = Convert.ToInt32(Console.ReadLine().Trim());
        int meetingsColumns = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> meetings = new List<List<int>>();

        for (int i = 0; i < meetingsRows; i++)
        {
            meetings.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(meetingsTemp => Convert.ToInt32(meetingsTemp)).ToList());
        }

        int result = Result.maximizeNonOverlappingMeetings(meetings);

        Console.WriteLine(result);
    }
}
