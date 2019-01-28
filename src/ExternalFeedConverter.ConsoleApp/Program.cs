using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;


namespace ExternalFeedConverter.ConsoleApp
{
    class Program
    {
        static void Main(String[] args)
        {

            var fileSanitiser = new FileDataUtilities(); // sanitise csv table by removing empty spaces
            fileSanitiser.Sanitise(@"..\..\src\ExternalFeedConverter.ConsoleApp\data\trees.csv", "trees1.csv");

            var fileLoader = new FileDataUtilities(); // loads data from csv file to dynamic collection type
            var treeList = fileLoader.LoadData(); 
            
            // prints table onto console
            Console.WriteLine("| Index | Girth | Height | Volume |");
            foreach (var tree in treeList)
            {
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("| {0} | {1} | {2} | {3} |", tree.Index, tree.Girth, tree.Height, tree.Volume);
            }
            
            var input = "";
            bool calculated = false;
            while (!calculated) // while loop to obtain calculations of desired attribute
            {   
                Console.Write("\nPlease enter the attribute (girth/height/volume) you would like to find the largest of: ");
                input = Console.ReadLine();
                string h = FirstLetterToUpper(input);
                calculated = calculateLargest(h, treeList);
                
            }
        }
        
        public static string FirstLetterToUpper(string s)
        {
            string h = s.ToLower(); // first step to convert entire string to lower case
            Console.WriteLine("\nObtaining tree with the largest {0}...", h);
            char[] a = h.ToCharArray(); // second step to create an array of characters from string
            a[0] = char.ToUpper(a[0]); // third step to turn first character into upper case
            return new string(a); // final step is to return new string
        }
        
        private static bool calculateLargest(string input, IEnumerable<dynamic> treeList)
        {
            double currentLargest = 0;
            string measurement = "";
            switch (input) // switch statement for each attribute
            {
                case "Girth":
                    measurement = "in";
                    currentLargest = findLargest(input);
                    break;
                case "Height":
                    measurement = "ft";
                    currentLargest = findLargest(input);
                    break;
                case "Volume":
                    measurement = "ft^3";
                    currentLargest = findLargest(input);
                    break;
                case "exit":
                    System.Threading.Thread.Sleep(500);
                    Environment.Exit(0);
                    break;
                default: // all other inputs other than attributes will return invalid input
                    Console.WriteLine("\nInvalid input! Try again.. or enter 'exit' to terminate.");
                    return false;
            }

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\nLargest Tree {0}: {1}{2}.", input, currentLargest, measurement);
            
            Console.WriteLine("\nWould you like to calculate another value? (y/n): ");
            var inp = Console.ReadLine();

            if(inp.Equals("y"))
                return false;
            return true;
        }

        public static double findLargest(string input)
        {
            double currentLargest = 0;
            
            var fileLoader = new FileDataUtilities();
            var treeList = fileLoader.LoadData();
            
            List<string> l = new List<string>();
            
            foreach (var tree in treeList) // for each loop to add all attribute values onto list
            {
                l.Add(tree.GetType().GetProperty(input).GetValue(tree, null));
            }
            
            List<double> result = l.Select(x => double.Parse(x)).ToList(); // converts all values to double
            
            foreach (double x in result) // compares each value to a current largest to obtain largest
            {
                if (x > currentLargest)
                {
                    currentLargest = x;
                }
            }
            
            return currentLargest;
        }
    }
}