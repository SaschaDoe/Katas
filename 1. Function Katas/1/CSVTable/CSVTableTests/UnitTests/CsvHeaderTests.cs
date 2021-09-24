
using System;
using System.Collections.Generic;
using System.Linq;
using CSVTable.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTableTests.UnitTests
{
    [TestClass]
    public class CsvHeaderTests
    {

        [TestMethod]
        [TestCategory("Unit")]
        public void ofNothing()
        {
            var actualCsvColumn = CsvHeader.Of(string.Empty);
            var expectedEnumerable = System.Array.Empty<object>();
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualCsvColumn.GetColumns()));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ofOnlyOneHeader()
        {
            var actualCsvColumn = CsvHeader.Of("Name");
            var expectedEnumerable = new List<string>() {"Name", "----"};
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualCsvColumn.GetColumns()));
        }
    }
}