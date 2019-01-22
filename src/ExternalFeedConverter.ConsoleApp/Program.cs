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
        static void Main(string[] args)
        {
            File.WriteAllLines("treesnew.csv", File.ReadAllLines(@"\_git\csharptraining\data\trees.csv").Where(l => !string.IsNullOrWhiteSpace(l)));

            var treeData = File.ReadAllLines(@"\_git\csharptraining\treesnew.csv");

            var treeList = from treeInfo in treeData
                           let data = treeInfo.Split(',')
                           select new
                           {
                               Index = data[0],
                               Girth = data[1],
                               Height = data[2],
                               Volume = data[3],
                           };

            foreach (var tree in treeList)
            {
                Console.WriteLine("| {0} | {1} | {2} | {3} |", tree.Index, tree.Girth, tree.Height, tree.Volume);
            }

            Console.WriteLine("\nPlease enter which maximum value you would like to obtain: (girth/height/volume) ");
            var input = Console.ReadLine();

            int index = 0;

            if (input.Equals("girth"))
            {
                Console.WriteLine("Obtaining the girth of widest tree...");

                double widest = 0;

                foreach (var tree in treeList.Skip(1))
                {
                    double current = Convert.ToDouble(tree.Girth);
                    if (current > widest)
                    {
                        widest = current;
                    }
                    index = Convert.ToInt16(tree.Index) + 1;
                }

                Console.WriteLine("The widest girth is ...... {0}in of Tree with index ..... {1}", widest, index);
            }
            else if (input.Equals("height"))
            {
                Console.WriteLine("Obtaining the height of tallest tree...");

                int tallest = 0;

                foreach (var tree in treeList.Skip(1))
                {
                    int current = Convert.ToInt16(tree.Height);
                    if (current > tallest)
                    {
                        tallest = current;
                        index = Convert.ToInt16(tree.Index) + 1;
                    }
                }
                Console.WriteLine("The tallest height is ...... {0}ft of Tree with index ..... {1}", tallest, index);
            }
            else if (input.Equals("volume"))
            {
                Console.WriteLine("Obtaining the volume of biggest tree...");

                double biggest = 0;

                foreach (var tree in treeList.Skip(1))
                {
                    double current = Convert.ToDouble(tree.Volume);
                    if (current > biggest)
                    {
                        biggest = current;
                    }
                    index = Convert.ToInt16(tree.Index) + 1;
                }

                Console.WriteLine("The largest volume is ...... {0}ft^3 of Tree with index ..... {1}", biggest, index);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

            Console.ReadLine();
        }
    }
}