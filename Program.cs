using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Loop to continuously generate and process bi-colored chips, until user exits
            while (true)
            {
                
                Console.Write("\nEnter the number of chips to generate (type 'exit' to end): ");
                string input = Console.ReadLine().Trim();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (!int.TryParse(input, out int numChips) || numChips <= 0 || numChips > 51)
                { 
                    Console.WriteLine("Invalid input. Please enter a positive integer (up to 50) or 'exit' to end.");
                    continue;
                }

                //Generate Ramdom chips
                ColorChip[] chips = ChipGenerator.GenerateRandomChips(numChips);


                //Printing randomly generated chips
                Console.WriteLine("\nRandomly generated chips:");
                foreach (var chip in chips)
                {
                    Console.WriteLine("[" + chip.ToString() + "]");
                }
                Console.WriteLine();

                //Method to find the long linked sequence
                List<ColorChip> result = FindLongestLink.FindLongestSequence(chips);

                if (result != null)
                {
                    Console.WriteLine("Successfully linked chips:");
                    foreach (var chip in result)
                    {
                        Console.Write("[" + chip.ToString() + "] ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(Constants.ErrorMessage);
                }

                Console.Write("\nPress any key to start again : ");
                Console.ReadKey();
            }
        }

             
        }
    }

