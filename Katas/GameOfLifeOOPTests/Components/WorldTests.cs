using System.Collections.Generic;
using System.Linq;
using GameOfLifeOOP.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeOOPTests.Components
{
    [TestClass]
    public class WorldTests
    {
        #region Constructor
        //TODO add property tests for 50%, 25% ...
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Generate_1TileWorld_WithIsAlive()
        {
            var world = new World(1, 1, new Percentage(100));
            
            var expectedCellGrid = new Cell[1][];
            expectedCellGrid[0] = new Cell[1];
            expectedCellGrid[0][0] = new Cell()
            {
                IsAlive = true
            };

            var expectedWorld = new World(expectedCellGrid);

            Assert.AreEqual(expectedWorld, world);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Generate_1TileWorld_WithNo_IsAlive()
        {
            var world = new World(1, 1, new Percentage(0));
            
            var expectedCellGrid = new Cell[1][];
            expectedCellGrid[0] = new Cell[1];
            expectedCellGrid[0][0] = new Cell()
            {
                IsAlive = false
            };

            var expectedWorld = new World(expectedCellGrid);

            Assert.AreEqual(expectedWorld, world);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Generate_1TileWorld_NoNeighbor()
        {
            var world = new World(1, 1, new Percentage(0));

            var neighbors = world.CellGrid[0][0].Neighbors;
            
            Assert.AreEqual(0, neighbors.ToList().Count);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Generate_2WidthTileWorld_Neighbor()
        {
            var world = new World(2, 1, new Percentage(0));

            var firstTileNeighbors = world.CellGrid[0][0].Neighbors;
            var secondTileNeighbors = world.CellGrid[1][0].Neighbors;
            
            Assert.AreEqual(world.CellGrid[1][0], firstTileNeighbors.ToList()[0]);
            Assert.AreEqual(world.CellGrid[0][0], secondTileNeighbors.ToList()[0]);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Generate_2HeightTileWorld_Neighbor()
        {
            var world = new World(1, 2, new Percentage(0));

            var firstTileNeighbors = world.CellGrid[0][0].Neighbors;
            var secondTileNeighbors = world.CellGrid[0][1].Neighbors;
            
            Assert.AreEqual(world.CellGrid[0][1], firstTileNeighbors.ToList()[0]);
            Assert.AreEqual(world.CellGrid[0][0], secondTileNeighbors.ToList()[0]);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Generate_4TileWorld_Neighbor()
        {
            var world = new World(2, 2, new Percentage(0));

            var firstTileNeighbors = world.CellGrid[0][0].Neighbors;
            var secondTileNeighbors = world.CellGrid[0][1].Neighbors;
            var thirdTileNeighbors = world.CellGrid[1][0].Neighbors;
            var fourthTileNeighbors = world.CellGrid[1][1].Neighbors;
            
            Assert.AreEqual(world.CellGrid[0][1], firstTileNeighbors.ToList()[0]);
            Assert.AreEqual(world.CellGrid[1][1], firstTileNeighbors.ToList()[1]);
            Assert.AreEqual(world.CellGrid[1][0], firstTileNeighbors.ToList()[2]);
            
            Assert.AreEqual(world.CellGrid[0][0], secondTileNeighbors.ToList()[0]);
            Assert.AreEqual(world.CellGrid[1][1], secondTileNeighbors.ToList()[1]);
            Assert.AreEqual(world.CellGrid[1][0], secondTileNeighbors.ToList()[2]);
            
            Assert.AreEqual(world.CellGrid[0][1], thirdTileNeighbors.ToList()[0]);
            Assert.AreEqual(world.CellGrid[1][1], thirdTileNeighbors.ToList()[1]);
            Assert.AreEqual(world.CellGrid[0][0], thirdTileNeighbors.ToList()[2]);
            
            Assert.AreEqual(world.CellGrid[0][1], fourthTileNeighbors.ToList()[0]);
            Assert.AreEqual(world.CellGrid[0][0], fourthTileNeighbors.ToList()[1]);
            Assert.AreEqual(world.CellGrid[1][0], fourthTileNeighbors.ToList()[2]);
        }

        #endregion

        #region NextTurn

        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurn_OneTile()
        {
            var cellGrid = new Cell[1][];
            cellGrid[0] = new Cell[1];
            cellGrid[0][0] = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
            };

            var world = new World(cellGrid);

            world.NextTurn();
            
            Assert.IsFalse(world.CellGrid[0][0].IsAlive);
        }

        #endregion
        
        #region Equals

        [TestMethod]
        [TestCategory("Unit")]
        public void Equals_False_When_Null()
        {
            var world = new World(1, 1, new Percentage(0));
            
            Assert.IsFalse(world.Equals(null));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Equals_True_When_SameObject()
        {
            var world = new World(1, 1, new Percentage(0));
            
            Assert.IsTrue(world.Equals(world));
        }

        #endregion

       
    }
}