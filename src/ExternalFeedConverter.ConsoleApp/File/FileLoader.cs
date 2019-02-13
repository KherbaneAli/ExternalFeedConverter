using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.ConsoleApp.Data;

namespace ExternalFeedConverter.ConsoleApp.File
{
    public class FileLoader : IFileLoader
    {
        public IEnumerable<DataItem> LoadData(string[] rows)
        {
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