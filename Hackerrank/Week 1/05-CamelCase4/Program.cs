using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            var operationType = data[0];
            var variableType = data[1];
            var variableName = data[2];
            

            // determine split or combine operation
            if (operationType.Equals("S"))
                Console.WriteLine(SplitLine(variableType, variableName));
            else
                Console.WriteLine(CombineLine(variableType, variableName));

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
        var result = new StringBuilder();
        foreach (string variableName in variableNames)
        {
            result.Append(Char.ToUpper(variableName[0]) + variableName.Substring(1));
        }

        if (type.Equals("C"))
            return result.ToString();

        // if it's not a class name make first letter lowercase
        result[0] = Char.ToLower(result[0]);
        if (type.Equals("M"))
            return result.Append("()").ToString();
        return result.ToString();
    }
}
