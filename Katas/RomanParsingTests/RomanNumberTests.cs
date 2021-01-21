using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanParsing;

namespace RomanParsingTests
{
    [TestClass]
    public class RomanNumberTests
    {

        #region Constructor

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_CreateNewRomanNumber()
        {
            var romanNumber = new RomanNumber(1);
            
            Assert.AreEqual(1, romanNumber.ArabicValue);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_ThrowsArgumentException_When_MinusOne()
        {
            var argumentException = Assert.ThrowsException<ArgumentException>(() => new RomanNumber(-1));
            Assert.AreEqual("No zero or minus values allowed", argumentException.Message);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_ThrowsArgumentException_When_Zero()
        {
            var argumentException = Assert.ThrowsException<ArgumentException>(() => new RomanNumber(0));
            Assert.AreEqual("No zero or minus values allowed", argumentException.Message);
        }

        #endregion

        #region Constructor string

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_String_ThrwosArgumentNullException_When_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new RomanNumber(null));
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_String_ArabicValueOne_When_I()
        {
            var romanNumber = new RomanNumber("I");

            Assert.AreEqual(1, romanNumber.ArabicValue);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_String_ArabicValueTwo_When_II()
        {
            var romanNumber = new RomanNumber("II");

            Assert.AreEqual(2, romanNumber.ArabicValue);
        }

        #endregion

        #region Create RomanNumber

        [TestMethod]
        [TestCategory("Unit")]
        public void Create_RomanNumber_I_When_I()
        {
            var romanNumber = RomanNumber.Create("I");
            
            romanNumber.Match(
                error => Assert.Fail(),
                result => Assert.AreEqual("I",result.ToString()));
            
        }

        #endregion


        #region ToString

        [TestMethod]
        [TestCategory("Unit")]
        public void ToString_XI_When_Six()
        {
            var romanNumber = new RomanNumber(6);
            const string expectedString = "VI";
            
            Assert.AreEqual(expectedString,romanNumber.ToString());
        }

        #endregion
    }
}