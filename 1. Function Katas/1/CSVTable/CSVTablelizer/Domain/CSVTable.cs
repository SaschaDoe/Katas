using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVTable.Domain
{
    public class CsvTable
    {
        public IEnumerable<string> Tablelize(IEnumerable<string> csvData)
        {
            if (csvData.ToList().Count == 0)
            {
                return csvData;
            }
            
            //Format data from csv to lists
            var columns = new List<List<string>>();
            foreach (var line in csvData)
            {
                var columnData = new List<string>(line.Split(";"));
                var dataList = new List<string>();
                foreach (var data in columnData)
                {
                    if (!data.Equals(""))
                    {
                        dataList.Add(data);
                    }
                }
                columns.Add(dataList);
            }

            //revert lists to columns
            string[][] table = new string[columns[0].Count][];
            for (var i = 0; i < table.Length; i++)
            {
                table[i] = new string[columns.Count];
                for (var n = 0; n < columns.Count; n++)
                {
                    table[i][n] = columns[n][i];
                }
            }
            
            //Format Columns
            var tableList = new List<List<string>>();
            foreach (var t in table)
            {
                var bla = CsvColumn.Of(new List<string>(t)).GetColumns();
                tableList.Add(bla.ToList());
            }
            
            //revert lists back to rows 
            var reversedTable = new string[tableList[0].Count][];
            for (var i = 0; i < reversedTable.Length; i++)
            {
                reversedTable[i] = new string[tableList.Count];
                for (var n = 0; n < tableList.Count; n++)
                {
                    reversedTable[i][n] = tableList[n][i];
                }
            }

            //parse table to rows
            var reversedTableList = new List<string>();
            foreach (var t in reversedTable)
            {
                reversedTableList.Add(string.Join(string.Empty,t));
            }

            return reversedTableList;
        }
    }
}