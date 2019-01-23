using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExternalFeedConverter.ConsoleApp
{
    class Program
    {
        static void Main(String[] args)
        {
            var fileSanitiser = new FileDataSanitiser();
            fileSanitiser.Sanitise(@"..\..\src\ExternalFeedConverter.ConsoleApp\data\trees.csv", "trees1.csv");
            
            var treeData = File.ReadAllLines(@"..\..\src\ExternalFeedConverter.ConsoleApp\trees1.csv");

            var treeList = from treeInfo in treeData
                           let data = treeInfo.Split(',')
                           select new
                           {
                               Index = data[0],
                               Girth = data[1],
                               Height = data[2],
                               Volume = data[3],
                           };
            Console.WriteLine("| Index | Girth | Height | Volume |");
            foreach (var tree in treeList.Skip(1))
            {
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("| {0} | {1} | {2} | {3} |", tree.Index, tree.Girth, tree.Height, tree.Volume);
            }
            
            var input = "";
            int index = 0;
            bool calculated = false;
            while (!calculated)
            {   
                Console.Write("\nPlease enter the attribute (girth/height/volume) you would like to find the largest of: ");
                input = Console.ReadLine();
                calculated = calculateLargest(input, treeList, ref index);
                
            }

            Console.ReadLine();
        }

        private static bool calculateLargest(string input, IEnumerable<dynamic> treeList, ref int index)
        {
            double currentLargest = 0;
            string measurement = "";
            switch (input)
            {
                case "girth":
                    measurement = "in";
                    foreach (var tree in treeList.Skip(1))
                    {
                        double current = Convert.ToDouble((string) tree.Girth);
                        if (current > currentLargest)
                        {
                            currentLargest = current;
                        }

                        index = Convert.ToInt16((string) tree.Index) + 1;
                    }
                    break;
                case "height":
                    measurement = "ft";
                    foreach (var tree in treeList.Skip(1))
                    {
                        int current = Convert.ToInt16((string) tree.Height);
                        if (current > currentLargest)
                        {
                            currentLargest = current;
                            index = Convert.ToInt16((string) tree.Index) + 1;
                        }
                    }
                    break;
                case "volume":
                    measurement = "ft^3";
                    foreach (var tree in treeList.Skip(1))
                    {
                        double current = Convert.ToDouble((string) tree.Volume);
                        if (current > currentLargest)
                        {
                            currentLargest = current;
                        }

                        index = Convert.ToInt16((string) tree.Index) + 1;
                    }
                    break;
                case "exit":
                    System.Threading.Thread.Sleep(500);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid input! Try again.. or enter 'exit' to terminate.");
                    return false;
            }

            string largest = currentLargest.ToString() + measurement;
            Console.WriteLine("\nObtaining tree with the largest {0}...", input);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\nTree Index: {0} Tree {1}: {2}.", index, input, largest);
            
            Console.Write("Would you like to calculate another value? (y/n): ");
            var inp = Console.ReadLine();

            if (inp.Equals("n"))
                return true;
            return true;
        }
    }
}