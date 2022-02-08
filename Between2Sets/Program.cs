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
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> a, List<int> b)
    {
        a.Sort();
        b.Sort();
      
        List<int> firstConditionNum = new List<int>();
        List<int> bothConditionNum = new List<int>();

        firstConditionNum = FirstConditionCheck(a, b);
        bothConditionNum = SecondConditionCheck(b, firstConditionNum);

        return bothConditionNum.Count;
    }
    private static List<int> SecondConditionCheck(List<int> b, List<int> firstConditionNum)
    {
        int m = b.Count;
        List<int> result = new List<int>();
        int counter2 = 0;

        for (int d = 0; d < firstConditionNum.Count; d++)
        {
            for (int k = 0; k < m; k++)
            {
                if (b[k] % firstConditionNum[d] != 0)
                {
                    counter2 = 0;
                    break;
                }
                else
                {
                    counter2++;
                }
                if (counter2 == m)
                {
                    result.Add(firstConditionNum[d]);
                    counter2 = 0;
                }
            }
        }

        return result;
    }

    private static List<int> FirstConditionCheck(List<int> a, List<int> b)
    {
        List<int> result = new List<int>();
        int counter = 0;
        int n = a.Count;

        // int lowLimitInterval = a[n - 1];
        // int highLimitInterval = b[0];
        //  int difference = highLimitInterval - lowLimitInterval;

        for (int i = a[n - 1]; i <= b[0]; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i % a[j] != 0)
                {
                    counter = 0;
                    break;
                }
                else
                {
                    counter++;
                }
                if (counter == n)
                {
                    result.Add(i);
                    counter = 0;
                }
            }
        }
        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
