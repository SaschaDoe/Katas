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
            return inputTable.Select<string[], string>(column => string.Join("|", FormatWidthSpaces(column, columnWidths)));
        }
        
        private static string[] FormatWidthSpaces(string[] column, int[] spaltenbreiten)
        {
            return column.Select((w, i) => w.PadRight(spaltenbreiten[i], ' ')).ToArray();
        }

        private static int[] GetMaxColumnWidths(string[][] inputTable)
        {
            var spaltenbreiten = inputTable.Select(v => v.Length).ToArray();
            return spaltenbreiten;
        }
    }
}