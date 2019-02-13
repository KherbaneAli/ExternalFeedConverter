using System;
using System.Collections.Generic;
using System.Threading;
using ExternalFeedConverter.ConsoleApp.Data;

namespace ExternalFeedConverter.ConsoleApp.Output
{
    public class OutputWriter : IOutputWriter
    {
        public void PrintTable(IEnumerable<DataItem> treeList)
        {
            Console.WriteLine("| Index | Girth | Height | Volume |");
            foreach (var tree in treeList)
            {
                Thread.Sleep(50);
                Console.WriteLine("| {0} | {1} | {2} | {3} |", tree.Index, tree.Girth, tree.Height, tree.Volume);
            }
        }
    }
}