using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVTable.Domain
{
    public class CsvHeader
    {
        private string[] _columns;

        public static CsvHeader Of(string csvColumnInput)
        {
           
            var csvHeader = new CsvHeader();
            if (csvColumnInput.Equals(""))
            {
                csvHeader._columns = System.Array.Empty<string>();
                return csvHeader;
            }
            
            var outputArray = Array.Empty<string>();

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(csvColumnInput);
            outputArray = new string[2];
            outputArray[0] = stringBuilder.ToString();
            stringBuilder = new StringBuilder();


            for (var i = 0; i < csvColumnInput.Length; i++)
            {
                stringBuilder.Append('-');
            }
            
            outputArray[1] = stringBuilder.ToString();


            csvHeader._columns = outputArray;
            return csvHeader;
        }

        public IEnumerable<string> GetColumns()
        {
            return _columns;
        }
    }
}