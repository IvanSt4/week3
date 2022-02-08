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


    public static int sockMerchant(int n, List<int> ar)
    {
        Stack<int> socksStack = new Stack<int>();

        int counter = 0;
        ar.Sort();

        foreach (var item in ar)
        {
            socksStack.Push(item);
        }

        for (int i = 0; i < n-1; i++)
        {
            int a = socksStack.Pop();
            int b = socksStack.Peek();
            if (a == b)
            {
                counter++;
                socksStack.Pop();
                i++;
            }

        }
        return counter;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

