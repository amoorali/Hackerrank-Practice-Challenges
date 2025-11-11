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
     * Complete the 'isNonTrivialRotation' function below.
     *
     * The function is expected to return a BOOLEAN.
     * The function accepts following parameters:
     *  1. STRING s1
     *  2. STRING s2
     */

    public static bool isNonTrivialRotation(string s1, string s2)
    {
        if (s1.Equals(s2))
            return false;

        if ((s1 + s1).Contains(s2))
            return true;

        return false;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        bool result = Result.isNonTrivialRotation(s1, s2);

        Console.WriteLine((result ? 1 : 0));
    }
}
