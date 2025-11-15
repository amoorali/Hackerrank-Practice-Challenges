using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {

        string line;
        var data = new string[3];

        while (true)
        {
            line = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(line))
                break;

            // break each line into 3 parts
            data = line.Trim().Split(';');

            // determine split or combine operation
            if (data[0].Equals("S"))
                Console.WriteLine(SplitLine(data[1], data[2]));
            else
                Console.WriteLine(CombineLine(data[1], data[2]));

        }
    }

    public static string SplitLine(string type, string name)
    {
        string result = String.Format("{0}", Char.ToLower(name[0]));
        for (int i = 1; i < name.Length; i++)
        {
            if (Char.IsUpper(name[i]))
                result += ' ';
            result += Char.ToLower(name[i]);
        }

        // if it's a method, remove the parentheses
        return result!.Trim(new Char[] { '(', ')' });
    }

    public static string CombineLine(string type, string name)
    {
        var variableNames = name.Split();
        var result = String.Empty;
        foreach (string variableName in variableNames)
        {
            result += Char.ToUpper(variableName[0]) + variableName.Substring(1);
        }

        if (type.Equals("C"))
            return result;

        // if it's not a class name make first letter lowercase
        result = Char.ToLower(result[0]) + result.Substring(1);
        if (type.Equals("M"))
            return result + "()";
        return result;
    }
}
