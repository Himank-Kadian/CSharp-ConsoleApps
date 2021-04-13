using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_portfolio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Purpose:    To take input values from the user and check whether they fall under or over the margin or if they are fine. 
                        The margin is specific to their input. 
 
            Input:      Estimated flight time, actual flight time
 
            Output:     Whether the estimated flight time is TOO SMALL or TOO LARGE or ACCEPTABLE.

            Author:           Himank Kadian 
            Last modified:    2019.10.02
            */
            Console.WriteLine("This program is used to determine if the estimated flight time is acceptable\n");
            Console.Write("Enter estimated flight time in minutes: ");
            int estFlightTime = int.Parse(Console.ReadLine());
            Console.Write("Enter actual flight time in minutes: ");
            int actualFlightTime = int.Parse(Console.ReadLine());
            int margin;
            if (estFlightTime < 0 || estFlightTime < 0)
                Console.Write("Invalid Input");
            if (estFlightTime >= 0 && estFlightTime <= 29)
                margin = 1;
            else if (estFlightTime >= 30 && estFlightTime <= 59)
                margin = 2;
            else if (estFlightTime >= 60 && estFlightTime <= 89)
                margin = 3;
            else if (estFlightTime >= 90 && estFlightTime <= 119)
                margin = 4;
            else if (estFlightTime >= 120 && estFlightTime <= 179)
                margin = 6;
            else if (estFlightTime >= 180 && estFlightTime <= 239)
                margin = 8;
            else if (estFlightTime >= 240 && estFlightTime <= 359)
                margin = 13;
            else
                margin = 17;

            int x = estFlightTime - actualFlightTime;

            if (x > margin)
                Console.WriteLine($"Estimated time is too large (by {x - margin} minutes) ");
            else if ((x+margin) < 0)
                Console.WriteLine($"Estimated time is too small (by {(x + margin) * (-1)} minutes) ");
            else
                Console.WriteLine($"Estimated time is acceptable ");


        }
    }
}

