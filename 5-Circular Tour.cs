/*Circular Tour Problem
Problem: Given a set of petrol pumps with petrol and distance to the next pump, determine the starting point for completing a circular tour.
Hint: Use a queue to simulate the tour, keeping track of surplus petrol at each pump.
*/

using System;
using System.Collections.Generic;


class CircularTour
{
    static int FindStartingPump(int[] petrol, int[] distance)
    {
        int start = 0, deficit = 0, balance = 0;


        for (int i = 0; i < petrol.Length; i++)
        {
            balance += petrol[i] - distance[i];
            if (balance < 0)
            {
                start = i + 1;
                deficit += balance;
                balance = 0;
            }
        }


        return (balance + deficit >= 0) ? start : -1;
    }


    static void Main()
    {
        int[] petrol = { 4, 6, 7, 4 };
        int[] distance = { 6, 5, 3, 5 };


        Console.WriteLine(FindStartingPump(petrol, distance));
    }
}


