using GameOfLifeFunctional;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameOfLifeFunctionalTests.UnitTests
{
    [TestClass]
    public class GameOfLifeTests
    {
        #region BoardIsOfSize

        [TestMethod]
        [TestCategory("Unit")]
        public void BoardIsOfSize_Width_One_Height_Two()
        {
            var gameOfLifeBoard = Board.Of((1, 2));
            
            Assert.AreEqual(
                (1,2),
                gameOfLifeBoard.Match(
                    () => (0,0), 
                    board => (board.Width,board.Height)));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void BoardIsOfSize_None_When_Width_Zero()
        {
            var gameOfLifeBoard = Board.Of((0, 2));
            
            Assert.IsTrue(
                gameOfLifeBoard.Match(
                    () => true, 
                    board => false));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void BoardIsOfSize_None_When_Width_MinusOne()
        {
            var gameOfLifeBoard = Board.Of((-1, 2));
            
            Assert.IsTrue(
                gameOfLifeBoard.Match(
                    () => true, 
                    board => false));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void BoardIsOfSize_None_When_Height_Zero()
        {
            var gameOfLifeBoard = Board.Of((1, 0));
            
            Assert.IsTrue(
                gameOfLifeBoard.Match(
                    () => true, 
                    board => false));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void BoardIsOfSize_None_When_Height_MinusOne()
        {
            var gameOfLifeBoard = Board.Of((1, -1));
            
            Assert.IsTrue(
                gameOfLifeBoard.Match(
                    () => true, 
                    board => false));
        }

        #endregion
    }
}