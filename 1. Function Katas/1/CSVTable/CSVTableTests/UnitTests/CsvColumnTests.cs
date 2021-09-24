
using System.Collections.Generic;
using System.Linq;
using CSVTable.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTableTests.UnitTests
{
    [TestClass]
    public class CsvColumnTests
    {

        [TestMethod]
        [TestCategory("Unit")]
        public void ofEmptyStringList()
        {

            var actualCsvColumn = CsvColumn.Of(new List<string>());
            var expectedEnumerable = System.Array.Empty<object>();
            var actualEnumerable = actualCsvColumn.GetColumns();
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualEnumerable));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ofOnlyOneHeader()
        {

            var actualCsvColumn = CsvColumn.Of(new List<string>(){"Name"});
            var expectedEnumerable = new List<string>() {"Name|", "----+"};
            var actualEnumerable = actualCsvColumn.GetColumns();
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualEnumerable));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ofHeaderAndOneLine()
        {

            var actualCsvColumn = CsvColumn.Of(new List<string>(){"Name","Bla"});
            var expectedEnumerable = new List<string>() {"Name|", "----+", "Bla |"};
            var actualEnumerable = actualCsvColumn.GetColumns();
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualEnumerable));
        }
        

        
        [TestMethod]
        [TestCategory("Unit")]
        public void ofHeaderAndOneLine_And_DataBiggerThanHeader()
        {

            var actualCsvColumn = CsvColumn.Of(new List<string>(){"Name","BlaBla"});
            var expectedEnumerable = new List<string>() {"Name  |", "------+", "BlaBla|"};
            var actualEnumerable = actualCsvColumn.GetColumns();
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualEnumerable));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ofHeaderAndMoreLines_And_DataBiggerThanHeader()
        {

            var actualCsvColumn = CsvColumn.Of(new List<string>(){"Name","BlaBla", "Bla"});
            var expectedEnumerable = new List<string>() {"Name  |", "------+", "BlaBla|", "Bla   |"};
            var actualEnumerable = actualCsvColumn.GetColumns();
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualEnumerable));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ofAgeList()
        {

            var actualCsvColumn = CsvColumn.Of(new List<string>(){"Alter","42", "43", "65"});
            var expectedEnumerable = new List<string>() {"Alter|", "-----+", "42   |", "43   |", "65   |"};
            var actualEnumerable = actualCsvColumn.GetColumns();
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualEnumerable));
        }
        
    }
}