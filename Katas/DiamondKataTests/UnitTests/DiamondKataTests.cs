using DiamondKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiamondKataTests.UnitTests
{
    [TestClass]
    public class DiamondKataTests
    {
        #region GetNumberOfLines

        [TestMethod]
        [TestCategory("Unit")]
        public void GetNumberOfLines_1_When_A()
        {
            var actualNumberOfLines = DiamondGenerator.GetLetterNumber('a');
            
            Assert.AreEqual(1,actualNumberOfLines);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void GetNumberOfLines_3_Wen_B()
        {
            var actualNumberOfLines = DiamondGenerator.GetLetterNumber('b');
            
            Assert.AreEqual(3,actualNumberOfLines);
        }

        #endregion
    }
}