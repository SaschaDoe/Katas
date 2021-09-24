using System.Collections.Generic;
using System.Linq;
using CSVTablelizerLinq.Application;
using CSVTablelizerLinq.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTablelizerLinqTests.AcceptanceTests
{
    [TestClass]
    public class CsvTableAcceptanceTests
    {
        private static IEnumerable<string> _oneLineTestInputCsv;
        private static string[][] _nothingTestInput;
        private static IEnumerable<string> _nothingExpected;
        private static IEnumerable<string> _headerTestInput;
        private static IEnumerable<string> _headerExpected;
        private static IEnumerable<string> _oneHeaderTestInput;
        private static IEnumerable<string> _oneHeaderExpected;
        private static IEnumerable<string> _acceptanceTestInput;
        private static IEnumerable<string> _acceptanceExpected;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _nothingTestInput = CsvParser.Parse(CsvReader.ReadDataFrom(@"./Resources/Input_Nothing.csv"));
            _nothingExpected = CsvReader.ReadDataFrom(@"./Resources/Expected_Nothing.txt");
            
            _oneHeaderTestInput = CsvReader.ReadDataFrom(@"./Resources/Input_JustOneHeader.csv");
            _oneHeaderExpected = CsvReader.ReadDataFrom(@"./Resources/Expected_JustOneHeader.txt");

            _headerTestInput = CsvReader.ReadDataFrom(@"./Resources/Input_JustHeader.csv");
            _headerExpected = CsvReader.ReadDataFrom(@"./Resources/Expected_JustHeader.txt");

            _acceptanceTestInput = CsvReader.ReadDataFrom(@"./Resources/Input_TablelizerAcceptance.csv");
            _acceptanceExpected = CsvReader.ReadDataFrom(@"./Resources/Expected_TablelizerAcceptance.txt");
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Nothing_When_NothingIsEntered()
        {
            var actualTablelizedData = Tablelizer.CreateTable(_nothingTestInput);
            
            Assert.IsTrue(_nothingExpected.SequenceEqual(actualTablelizedData));
        }
        /*
        [TestMethod]
        [TestCategory("Unit")]
        public void OneHeader_When_OnlyOneHeaderIsGiven()
        {
            var csvTable = new CsvTable();
            var actualTablelizedData = csvTable.Tablelize(_oneHeaderTestInput);
            
            Assert.IsTrue(_oneHeaderExpected.SequenceEqual(actualTablelizedData));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Header_When_OnlyHeaderIsGiven()
        {
            var csvTable = new CsvTable();
            var actualTablelizedData = csvTable.Tablelize(_headerTestInput);
            
            Assert.IsTrue(_headerExpected.SequenceEqual(actualTablelizedData));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void StandardInputTest()
        {
            
            var csvTable = new CsvTable();
            var actualTablelizedData = csvTable.Tablelize(_acceptanceTestInput);
            Assert.IsTrue(_acceptanceExpected.SequenceEqual(actualTablelizedData));
        }*/
    }
}