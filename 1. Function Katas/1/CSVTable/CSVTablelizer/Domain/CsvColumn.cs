using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSVTable.Domain
{
    public class CsvColumn
    {
        private CsvHeader _csvHeader;
        private string[] _columns;

        private int getMaxOfAllColumns(List<string> rows)
        {
            var maximum = 0;
            foreach (var row in rows)
            {
                if (row.Length > maximum)
                {
                    maximum = row.Length;
                }
            }

            return maximum;
        }

        public static CsvColumn Of(List<string> csvColumnInput)
        {

            var csvColumn = new CsvColumn();
            if (csvColumnInput.Count == 0)
            {
                csvColumn._columns = Array.Empty<string>();
                return csvColumn;
            }

            var header = csvColumnInput[0];
            var data = csvColumnInput.GetRange(1, csvColumnInput.Count - 1);
            csvColumn._csvHeader = CsvHeader.Of(header);
            
           

            var headerColumns = csvColumn._csvHeader.GetColumns().ToArray();
            if (data.Count == 0)
            {
                var columns = new string[]
                {
                    headerColumns[0] + "|",
                    headerColumns[1] + "+"
                };
                csvColumn._columns = columns;
            
                return csvColumn;
            }

            var maxLength = csvColumn.getMaxOfAllColumns(data);
            if (header.Length > maxLength)
            {
                var headerExtendedColumns = new string[]
                {
                    headerColumns[0] + "|",
                    headerColumns[1] + "+"
                };
                csvColumn._columns = headerExtendedColumns;
                
                foreach (var line in data)
                {
                    var stringBuilder = new StringBuilder();
                    var sub = header.Length - maxLength;
                    stringBuilder.Append(line);
                    for (var i = 0; i < sub; i++)
                    {
                        stringBuilder.Append(' ');
                    }
                    stringBuilder.Append('|');
                    csvColumn._columns = csvColumn._columns.Concat(new[] {stringBuilder.ToString()}).ToArray();
                }
            }
            else
            {
                var spaces = "";
                for (var i = 0; i < maxLength - header.Length; i++)
                {
                    spaces += " ";
                }
                
                var lines = "";
                for (var i = 0; i < maxLength - header.Length; i++)
                {
                    lines += "-";
                }

                var headerExtendedColumns = new string[]
                {
                    headerColumns[0] + spaces + "|",
                    headerColumns[1] + lines + "+"
                };
                csvColumn._columns = headerExtendedColumns;
                
                foreach (var line in data)
                {
                    var spacess = "";
                    for (var i = 0; i < maxLength - line.Length; i++)
                    {
                        spacess += " ";
                    }
                    
                    var stringBuilder = new StringBuilder();
                    stringBuilder.Append(line);
                    stringBuilder.Append(spacess+'|');
                    csvColumn._columns = csvColumn._columns.Concat(new[] {stringBuilder.ToString()}).ToArray();
                }
            }

            return csvColumn;
        }

        public IEnumerable<string> GetColumns()
        {
            if (_csvHeader == null)
            {
                return new string[]{};
            }

            return _columns;
        }
    }
}