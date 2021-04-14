using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_1
{
    class Program
    {
        static void Main(string[] args)
        { /* 
            Purpose:    To take input values from the user and provide them with the compounded value of their principal amount. 
 
            Input:      Principal amount(p), annual interest rate(r), number of times the interest is compounded(n) and total number of years(t).
 
            Output:     Compounded future value of the amount(f).
             
            Author:           Himank Kadian 
            Last modified:    2019.09.19
            */


            Console.WriteLine("This program is used to calculate the future investment value.\n");

            Console.Write("Enter investment amount: ");
            double p = double.Parse(Console.ReadLine());

            Console.Write("Enter anual interest rate in percentage: ");
            double r = double.Parse(Console.ReadLine());
            double rdecimal = r / 100;

            Console.WriteLine("Compound periods can be 1 for yearly, 2 for semi-annually, 4 for quaterly, or 12 for monthly");
            Console.Write("Enter number of compound periods (1,2,4,12): ");
            double n = double.Parse(Console.ReadLine());

            Console.Write("Enter number of years: ");
            double t = double.Parse(Console.ReadLine());

            double f;
            f = p * (Math.Pow((1 + rdecimal / n), (n * t)));
            Console.WriteLine($"\nFuture value is {f:c}");
            Console.WriteLine($"Investment amount : {p:c}");
            Console.WriteLine($"Annual Interest Rate : {r}%");
            Console.WriteLine($"Compunds per year: {n}");
        }
    }
}
