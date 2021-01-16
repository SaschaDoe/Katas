using DiamondKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiamondKataTests.AcceptanceTests
{
    [TestClass]
    public class DiamondKataAcceptanceTests
    {
        [TestMethod]
        [TestCategory("Acceptance")]
        public void A_Diamond()
        {
            var actualDiamondString = DiamondGenerator.GenerateDiamondString('a');
            Assert.AreEqual("A", actualDiamondString);
        }
        
        [TestMethod]
        [TestCategory("Acceptance")]
        public void B_Diamond()
        {
            var actualDiamondString = DiamondGenerator.GenerateDiamondString('b');
            Assert.AreEqual(@" A 
B B 
 A ", actualDiamondString);
        }
        
        [TestMethod]
        [TestCategory("Acceptance")]
        public void C_Diamond()
        {
            var actualDiamondString = DiamondGenerator.GenerateDiamondString('c');
            Assert.AreEqual(@"  A  
 B B 
C   C
 B B  
  A  ", actualDiamondString);
        }
    }
}