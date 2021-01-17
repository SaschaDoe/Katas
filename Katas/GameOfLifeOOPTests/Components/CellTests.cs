using System.Collections.Generic;
using GameOfLifeOOP.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeOOPTests.Components
{
    [TestClass]
    public class CellTests
    {
        #region ToString

        [TestMethod]
        [TestCategory("Unit")]
        public void ToStringTest_Star_When_IsAlive()
        {
            var cell = new Cell()
            {
                IsAlive = true
            };
            
            Assert.AreEqual("*",cell.ToString());
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ToStringTest_Point_When_IsNotAlive()
        {
            var cell = new Cell()
            {
                IsAlive = false
            };
            
            Assert.AreEqual(".",cell.ToString());
        }

        #endregion

        #region NextTurnAlive

        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurnAlive_False_When_NoNeighbors()
        {
            var cell = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
            };
            
            Assert.IsFalse(cell.IsAliveNextTurn);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurnAlive_False_When_OneLivingNeighbor()
        {
            var cell = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
                {
                    new Cell()
                    {
                        IsAlive = true
                    }
                }
            };
            
            Assert.IsFalse(cell.IsAliveNextTurn);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurnAlive_True_When_Living_And_TwoLivingNeighbor()
        {
            var neighborCell = new Cell()
            {
                IsAlive = true
            };
            var cell = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
                {
                    neighborCell, neighborCell
                }
            };
            
            Assert.IsTrue(cell.IsAliveNextTurn);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurnAlive_True_When_Living_And_ThreeLivingNeighbor()
        {
            var neighborCell = new Cell()
            {
                IsAlive = true
            };
            var cell = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
                {
                    neighborCell, neighborCell, neighborCell
                }
            };
            
            Assert.IsTrue(cell.IsAliveNextTurn);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurnAlive_False_When_Living_And_OneLivingNeighbor()
        {
            var neighborCell = new Cell()
            {
                IsAlive = true
            };
            var cell = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
                {
                    neighborCell, 
                }
            };
            
            Assert.IsFalse(cell.IsAliveNextTurn);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurnAlive_False_When_Living_And_FourLivingNeighbor()
        {
            var neighborCell = new Cell()
            {
                IsAlive = true
            };
            var cell = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
                {
                    neighborCell, 
                }
            };
            
            Assert.IsFalse(cell.IsAliveNextTurn);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurnAlive_True_When_Dead_And_ThreeLivingNeighbor()
        {
            var neighborCell = new Cell()
            {
                IsAlive = true
            };
            var cell = new Cell()
            {
                IsAlive = false,
                Neighbors = new List<Cell>()
                {
                    neighborCell, neighborCell, neighborCell
                }
            };
            
            Assert.IsTrue(cell.IsAliveNextTurn);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void NextTurnAlive_False_When_Dead_And_TwoLivingNeighbor()
        {
            var neighborCell = new Cell()
            {
                IsAlive = true
            };
            var cell = new Cell()
            {
                IsAlive = false,
                Neighbors = new List<Cell>()
                {
                    neighborCell, neighborCell
                }
            };
            
            Assert.IsFalse(cell.IsAliveNextTurn);
        }

        #endregion

        #region LivingNeighbors

        [TestMethod]
        [TestCategory("Unit")]
        public void LivingNeighbors_Zero_WhenNoLivingNeighbor()
        {
            var neighborCell = new Cell()
            {
                IsAlive = false
            };

            var cell = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
                {
                    neighborCell
                }
            };
            
            Assert.AreEqual(0,cell.LivingNeighborCount);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void LivingNeighbors_One_WhenLivingNeighbor()
        {
            var neighborCell = new Cell()
            {
                IsAlive = true
            };

            var cell = new Cell()
            {
                IsAlive = true,
                Neighbors = new List<Cell>()
                {
                    neighborCell
                }
            };
            
            Assert.AreEqual(1,cell.LivingNeighborCount);
        }

        #endregion

        #region Equals

        [TestMethod]
        [TestCategory("Unit")]
        public void Equals_True_When_SameObject()
        {
            var cell = new Cell();
            Assert.IsTrue(cell.Equals(cell));
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void Equals_False_When_Null()
        {
            var cell = new Cell();
            Assert.IsFalse(cell.Equals(null));
        }


        #endregion
    }
}