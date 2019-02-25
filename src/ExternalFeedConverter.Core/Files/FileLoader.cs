using System;
using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Files
{
    public class FileLoader : IFileLoader
    {
        public IEnumerable<DataItem> LoadData(string[] rows)
        {
            if (rows.Length == 0)
                return ArraySegment<DataItem>.Empty;
                

            var treeList = from row in rows.Skip(1)
                let data = row.Split(',')
                select new DataItem
                (
                    data[0],
                    data[1],
                    data[2],
                    data[3]
                );

            return treeList;
        }
    }
}