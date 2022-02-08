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
     * Complete the 'maximumPerimeterTriangle' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY sticks as parameter.
     */

    public static List<int> maximumPerimeterTriangle(List<int> sticks)
    {
       // List<int> result = new List<int>();
        sticks.Sort();
        int n = sticks.Count();

        Stack<List<long>> threeTuples = new Stack<List<long>>();

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                for (int k = j+1; k < n; k++)
                {
                    List<long> threeNum = new List<long>();
                    threeNum.Add((long)sticks[i]);
                    threeNum.Add((long)sticks[j]);
                    threeNum.Add((long)sticks[k]);
                    threeTuples.Push(threeNum);
                }
            }
        }

        int t = threeTuples.Count();
        List<List<long>> validTriangles = new List<List<long>>();
        int counter = 0;

        for (int i = 0; i < t; i++)
        {
            List<long> a = new List<long>();
            a = threeTuples.Pop();
            for (int s = 0; s < 3; s++)
            {
                if (a.Sum() <= 2* a[s])
                {
                    break;
                }
                else
                {                  
                    counter++;                    
                }

            }
            if (counter == 3)
            {
                List<int> b = new List<int>();
                validTriangles.Add(a);
                foreach (var item in a)
                {
                    int c = Convert.ToInt32(item);
                    b.Add(c);
                }

                return b;
            }
            counter = 0;
        }
        
        List<int> result1 = new List<int>() { -1 };
        return result1;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> sticks = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sticksTemp => Convert.ToInt32(sticksTemp)).ToList();

        List<int> result = Result.maximumPerimeterTriangle(sticks);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
