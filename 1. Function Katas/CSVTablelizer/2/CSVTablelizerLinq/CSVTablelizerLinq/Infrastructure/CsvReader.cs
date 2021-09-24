using System.Collections.Generic;
using System.IO;

namespace CSVTablelizerLinq.Infrastructure
{
    public class CsvReader
    {

        public static IEnumerable<string> ReadDataFrom(string path)
        {
            using var reader = new StreamReader(path);
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                yield return line;
            }
        }
    }
}