using System.Collections.Generic;
using System.Linq;

namespace ExternalFeedConverter.ConsoleApp
{
    public class FileLoader
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