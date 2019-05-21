using System;
using System.Collections.Generic;
using System.Threading;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Output
{
    public class OutputWriter : IOutputWriter
    {
        public void PrintTable(IEnumerable<DataItem> treeList)
        {
            Console.WriteLine("| Index | Girth | Height | Volume | Type | Chopped |");
            Console.WriteLine("|-------|-------|--------|--------|------|---------|");
            foreach (var tree in treeList)
            {
                Thread.Sleep(50);
                Console.WriteLine("|   {0}   |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |", tree.Index, tree.Girth, tree.Height, tree.Volume, tree.Type, tree.Chopped);
            }
        }
    }
}