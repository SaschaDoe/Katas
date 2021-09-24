using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSVTablelizerLinq.Application
{
    public static class Tablelizer
    {
        public static IEnumerable<string> CreateTable(string[][] inputTable)
        {
            var columnWidths = GetMaxColumnWidths(inputTable);
            return FormatColumns(inputTable, columnWidths);
        }

        private static IEnumerable<string> FormatColumns(string[][] inputTable, int[] columnWidths)
        {
            if (inputTable.Length == 0)
            {
                return Array.Empty<string>();
            }
            
            var allColumns = inputTable.Select(column => 
                string.Join("|", 
                    FormatWidthSpaces(column, columnWidths)));

            var linesWithoutPlus = GetFormatedLine(columnWidths);
            var lines = AddPlusSignTo(linesWithoutPlus);

            var headerWithDelimeter = allColumns.First()+"|";
            var header = new [] {headerWithDelimeter};
            var rest = allColumns.Skip(1).Select(line => line+"|");

            var fullList = header.Append(lines).Concat(rest);
            
            return fullList;
        }

        private static string AddPlusSignTo(IEnumerable<string> lines)
        {
            var bla = string.Join("",lines.Select(line => line+'+').ToList());
            return bla;
        }
        
        private static IEnumerable<string> GetFormatedLine(int[] columnWidths)
        {
            var bla = columnWidths.Select(width => "".PadRight(width, '-'));
            return bla;
        }
        
        private static string[] FormatWidthSpaces(IEnumerable<string> column, IReadOnlyList<int> columnWidths)
        {
            var bla = column.Select((w, i) => 
                w.PadRight(columnWidths[i], ' ')).ToArray();
            return bla;
        }

        private static int[] GetMaxColumnWidths(string[][] inputTable)
        {
            
            if (inputTable == null)
            {
                return Array.Empty<int>();
            }
            
            if (inputTable.Length == 0)
            {
                return Array.Empty<int>();
            }
            var columnWidths = new int[inputTable[0].Length];
            for (var i = 0; i < columnWidths.Length; i++)
            {
                columnWidths[i] =  inputTable.Select(r => r[i]).Max(v => v.Length);
            }
            return columnWidths;
        }
    }
}