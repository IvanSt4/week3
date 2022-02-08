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
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {
        //List<int> orderAr = new List<int>();
        //arr.Sort();
      //  int a = arr.Count(); //(x => x== 5);


        var counts = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        int max = counts.Max(kvp => kvp.Value);
        return counts.Where(kvp => kvp.Value == max).Select(kvp => kvp.Key).First();
      //   max = counts.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

     //   int b = counts.Count;
      //  return a;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
