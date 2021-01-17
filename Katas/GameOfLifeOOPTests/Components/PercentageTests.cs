using System;
using GameOfLifeOOP.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeOOPTests.Components
{
    [TestClass]
    public class PercentageTests
    {
        #region Constructor

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_SetValue()
        {
            var percentage = new Percentage(0);
            
            Assert.AreEqual(0,percentage.Value);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_ArgumentException_When_MinusOne()
        {
            var argumentException = Assert.ThrowsException<ArgumentException>(() => new Percentage(-1));
            Assert.AreEqual($"{nameof(Percentage)} must not be smaller than 0", argumentException.Message);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_ArgumentException_When_HundredOne()
        {
            var argumentException = Assert.ThrowsException<ArgumentException>(() => new Percentage(101));
            Assert.AreEqual($"{nameof(Percentage)} must not be greater than 100", argumentException.Message);
        }
        

        #endregion
    }
}