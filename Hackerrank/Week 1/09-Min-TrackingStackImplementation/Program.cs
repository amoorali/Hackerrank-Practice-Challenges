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
     * Complete the 'processCouponStackOperations' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY operations as parameter.
     */

    public static List<int> processCouponStackOperations(List<string> operations)
    {
        var stack = new List<int>();
        var result = new List<int>();

        foreach (var operation in operations)
        {
            var op = operation.Split();
            if (op[0] == "push") stack.Add((Int32.Parse(op[1])));
            else if (op[0] == "pop") stack.RemoveAt(stack.Count - 1);
            else if (op[0] == "top") result.Add(stack.ElementAt(stack.Count - 1));
            else if (op[0] == "getMin") result.Add(stack.Min());
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int operationsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> operations = new List<string>();

        for (int i = 0; i < operationsCount; i++)
        {
            string operationsItem = Console.ReadLine();
            operations.Add(operationsItem);
        }

        List<int> result = Result.processCouponStackOperations(operations);

        Console.WriteLine(String.Join("\n", result));
    }
}
