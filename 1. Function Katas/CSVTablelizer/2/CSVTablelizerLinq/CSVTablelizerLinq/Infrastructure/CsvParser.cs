using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVTablelizerLinq.Infrastructure
{
    public static class CsvParser
    {
        public static string[][] Parse(IEnumerable<string> csvText)
        {
            return csvText.Select(csvLine => csvLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .ToArray();
        } 

    }
}