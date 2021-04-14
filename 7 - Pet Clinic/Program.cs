using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP4_list_objects_PetPainKiller
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goAgain = true;
            while (goAgain) 
            {
                int petWeight = 0;
                char petType = 'x';
                bool invalidInput = true;
                while (invalidInput)
                {
                    Console.WriteLine("|---------------------|");
                    Console.WriteLine("|      Pet Clinic     |");
                    Console.WriteLine("|---------------------|");
                    string petName = NameCheck("Enter the name of your pet: ");
                    int petAge = AgeCheck("Enter the age in years of your pet: ");
                    petWeight = WeightCheck("Enter the weight in pounds of your pet: ");
                    petType = PetTypeCheck("Enter D for Dog or C for Cat: ");
                    Console.WriteLine($"Name: {petName}, Age: {petAge} years, Weight: {petWeight}lbs, Type: {petType}");
                    Console.WriteLine("Is this info correct? Enter Y or N");
                    char correctInfo = char.Parse(Console.ReadLine().ToUpper());
                    if (correctInfo == 'Y')
                        invalidInput = false;
                    else if (correctInfo == 'N')
                    {
                        Console.WriteLine("Lets try that again.");
                        invalidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Assuming the info is wrong and restarting");
                        invalidInput = true;
                    }
                }
                int service = ServiceOptions();
                double dosage = 0.00;
                if (service == 1)
                {
                    dosage = Carprofen(petWeight, petType);
                    Console.WriteLine ($"Your pet required {dosage:n3}ml of Carprofen");
                }
                else if (service == 2)
                {
                    dosage = Acepromazine(petWeight, petType);
                    Console.WriteLine ($"Your pet required {dosage:n3}ml of acepromazine");
                }
                else
                {
                    dosage = Acepromazine(petWeight, petType);
                    double dosage1 = Carprofen(petWeight, petType);
                    Console.WriteLine ($"Your pet required {dosage1:n3}ml of Carprofen");
                    Console.WriteLine ($"Your pet required {dosage:n3}ml of acepromazine");
                }
                Console.WriteLine("Another pet that requires service? Y/N");
                char again = char.Parse(Console.ReadLine().ToUpper());
                if (again == 'Y')
                    goAgain = true;
                else if (again == 'N')
                {
                    Console.WriteLine("Thank you for coming");
                    goAgain = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Exiting service.");
                    goAgain = false;
                }

            }
        }

        static string NameCheck(string prompt)
        {
            string petName = "";
            bool invalidInput = true;
            while (invalidInput)
            {
                try
                {
                Console.Write($"{prompt}");
                petName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(petName))
                {
                    Console.WriteLine("Must provide a pet name");
                    invalidInput = true;
                }
                else
                    invalidInput = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Try again.");
                }
            } 
            return petName;
        }

        static int AgeCheck(string prompt)
        {
            int petAge = 0;
            bool invalidInput = true;
            while (invalidInput)
            {
                try
                {
                Console.Write($"{prompt}");
                petAge = int.Parse(Console.ReadLine());

                if (petAge < 1)
                {
                    Console.WriteLine("Pet must be at least 1 year old");
                    invalidInput = true;
                }
                else
                    invalidInput = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Try again.");
                }
            } 
            return petAge;
        }

        static int WeightCheck(string prompt)
        {
            int petWeight = 0;
            bool invalidInput = true;
            while (invalidInput)
            {
                try
                {
                Console.Write($"{prompt}");
                petWeight = int.Parse(Console.ReadLine());

                if (petWeight < 5)
                {
                    Console.WriteLine("Pet weight must be at least 5 pounds");
                    invalidInput = true;
                }
                else
                    invalidInput = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Try again.");
                }
            } 
            return petWeight;
        }

         static char PetTypeCheck(string prompt)
         {
            char petType = ' ';
            bool invalidInput = true;
            while (invalidInput)
            {
                try
                {
                Console.Write($"{prompt}");
                petType = char.Parse(Console.ReadLine().ToUpper());

                if (petType == 'C' || petType == 'D')
                    invalidInput = false;

                else
                {
                    Console.WriteLine("Invalid input. Enter C for Cat or D for Dog");
                    invalidInput = true;
                }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Try again.");
                }
            } 
            return petType;
        }

        static int ServiceOptions()
        {
            int service = 0;
            bool invalidInput = true;
            while (invalidInput)
            {
                Console.WriteLine("Service options");
                Console.WriteLine("1. Pain Killer");
                Console.WriteLine("2. Sedative");
                Console.WriteLine("3. Both");
                Console.Write("Enter the service (1-3) for your pet: ");
                service = int.Parse(Console.ReadLine());
                if (service == 1 || service == 2 || service == 3)
                    invalidInput = false;
                else
                    Console.WriteLine("Invalid input. Try again.");
            }
            return service;
        }

        static double Acepromazine(int petWeight, char petType)
        {
            double dosage;
            if (petType == 'D')
                dosage = (petWeight/2.205) * (0.03/10);
            else
                dosage = (petWeight/2.205) * (0.002/10);

            return dosage;
        }

        static double Carprofen(int petWeight, char petType)
        {
            double dosage;
            if (petType == 'D')
                dosage = (petWeight/2.205) * (0.5/12);
            else
                dosage = (petWeight/2.205) * (0.25/12);

            return dosage;
        }
    }
}
