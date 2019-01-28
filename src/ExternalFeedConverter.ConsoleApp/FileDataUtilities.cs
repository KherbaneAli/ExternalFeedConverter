using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ExternalFeedConverter.ConsoleApp
{
    public class FileDataUtilities
    {
        public void Sanitise(string input, string output)
        {
            File.WriteAllLines(output, File.ReadAllLines(input).Where(l => !string.IsNullOrWhiteSpace(l)));
        }
        
        public IEnumerable<dynamic> LoadData()
        {
            var treeData = File.ReadAllLines(@"..\..\src\ExternalFeedConverter.ConsoleApp\trees1.csv");

            var treeList = from treeInfo in treeData.Skip(1)
                let data = treeInfo.Split(',')
                select new
                {
                    Index = data[0],
                    Girth = data[1],
                    Height = data[2],
                    Volume = data[3],
                };

            return treeList;
        }
    }
}