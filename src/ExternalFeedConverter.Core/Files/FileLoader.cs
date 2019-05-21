using System;
using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Extensions;

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
                    data[0].ToInt(),
                    data[1].ToDouble(),
                    data[2].ToDouble(),
                    data[3].ToDouble(),
                    data[4],
                    data[5].ToBoolean()
                );

            return treeList;
        }
    }
}