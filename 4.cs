/* Problem 2: Compare StringBuilder Performance
Problem: Write a program that compares the performance of StringBuilder for concatenating strings multiple times.
*/

using System;
using System.Diagnostics;
using System.Text;


class Program
{
    static void Main()
    {
        int count = 10000;
       
        Stopwatch sw = new Stopwatch();
       
        sw.Start();
        string result = "";
        for (int i = 0; i < count; i++)
        {
            result += "a";
        }
        sw.Stop();
        Console.WriteLine("String Time: " + sw.ElapsedMilliseconds + "ms");


        sw.Restart();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append("a");
        }
        sw.Stop();
        Console.WriteLine("StringBuilder Time: " + sw.ElapsedMilliseconds + "ms");
    }
}
