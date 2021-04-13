using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_file_list_objects_TriviaGame
{
    class FuelGauge 
    {
        private double _currentFuel;
        public double currentFuel
        {
            get { return _currentFuel; }
            set { _currentFuel = value; }
        }

        public double AddFuel(int amount, double currentFuelAmount)
        {
            currentFuel = currentFuelAmount;
            for (int i = 1; i <= amount; i++)
            {
                currentFuel = currentFuel + 1;
                if (currentFuel > 60)
                {
                    currentFuel = 60;
                    Console.WriteLine("Can only add a max of 60l of fuel. Removing amount more than 60");
                    i = amount;
                }
            }

            return currentFuel;
        }

        public double BurnFuel (double currentFuelAmount)
        {
            currentFuelAmount = currentFuelAmount - 0.12;
            return currentFuelAmount;
        }
        
        public void FuelAmount(string msg, double currentFuelAmount)
        {
            Console.WriteLine($"{msg} {currentFuelAmount:n2}L");
        }
    }

    class Odometer
    {
        public int currentKM;

        public double DriveCar(int distance, double currentFuelAmount)
        {
            FuelGauge fuel = new FuelGauge();
            for (int i = 1; i <= distance; i++)
            {
                currentKM = currentKM + 1;
                if (currentKM > 999)
                    currentKM = 0;

                currentFuelAmount = fuel.BurnFuel(currentFuelAmount);
                Console.WriteLine($"Distance Travelled: {currentKM} Fuel right now: {currentFuelAmount:n2}");
                if (currentFuelAmount < 0.12)
                {
                    Console.WriteLine("Please add more fuel");
                    i = distance;
                }
            }
            Console.WriteLine($"Total distance travelled after this journey {currentKM}km");
            return currentFuelAmount;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            FuelGauge fuel = new FuelGauge();
            fuel.currentFuel = 0;

            double currentFuelAmount = 0;

            Odometer km = new Odometer();
            km.currentKM = 0;
            bool again = true;
            while(again)
            {
                try
                {
                    Console.WriteLine("|------------------------|");
                    Console.WriteLine("| CPSC1012 Car Simulator |");
                    Console.WriteLine("|------------------------|");
                    Console.WriteLine("| 1. Add Fuel            |");
                    Console.WriteLine("| 2. Drive Car           |");
                    Console.WriteLine("| 0. Exit                |");
                    Console.WriteLine("|------------------------|");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        Console.Write("Enter amount of fuel: ");
                        int amount = int.Parse(Console.ReadLine());
                        currentFuelAmount = fuel.AddFuel(amount, currentFuelAmount);
                        fuel.FuelAmount("Initial fuel amount: ", currentFuelAmount);
                    }

                    else if (option ==  2)
                    {
                        Console.Write("Enter distance: ");
                        int distance = int.Parse(Console.ReadLine());
                        currentFuelAmount = km.DriveCar(distance, currentFuelAmount);
                        fuel.FuelAmount("Fuel left after journey: ", currentFuelAmount);
                    }

                    else if (option == 0)
                    {
                        Console.WriteLine("Goodbye!");
                        again = false;
                    }

                    else
                        Console.WriteLine("Invalid input. Enter a number from 0-2");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Try again.");
                }
            }
        }
    }
}
/*
 class Odometer
    {
        public int currentKM;

        public double DriveCar(int distance, double currentFuelAmount)
        {
            FuelGauge fuel = new FuelGauge();
            if (currentFuelAmount > (currentFuelAmount - distance * 0.12))
            {
            for (int i = 1; i <= distance; i++)
            {
                currentKM = currentKM + 1;
                currentFuelAmount = fuel.BurnFuel(currentFuelAmount);
                Console.WriteLine($"Distance Travelled: {currentKM} Fuel right now: {currentFuelAmount:n2}");
                if (currentFuelAmount < 0.12)
                {
                    Console.WriteLine("Please add more fuel");
                    break;
                }
            }
            }
            else
                Console.WriteLine("Not enough fuel for that journey!!");
            Console.WriteLine($"Total distance travelled after this journey {currentKM}km");
            return currentFuelAmount;
        }
    }
 */