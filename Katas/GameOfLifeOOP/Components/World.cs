using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeOOP.Components
{
    public class World : IEquatable<World>
    {
        public Cell[][] CellGrid { get; }
        public int Width { get; }
        public int Height { get; }
        
        /// <summary>
        /// Constructs a world 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="percentage">Percentage of the possibility that a cell is alive at the beginning</param>
        public World(int width, int height, Percentage percentage)
        {
            Width = width;
            Height = height;
            CellGrid = GenerateEmptyWorld(width, height, percentage);
            
        }

        /// <summary>
        /// Constructs a World by setting the cell grid directly
        /// </summary>
        /// <param name="cellGrid"></param>
        public World(Cell[][] cellGrid)
        {
            Width = cellGrid.Length;
            Height = cellGrid[0].Length;
            CellGrid = cellGrid;
        }
        
        /// <summary>
        /// Apply the game of life rules on every cell
        /// </summary>
        public void NextTurn()
        {
            var nextTurnLivingStatus = GetCellsNextTurnAliveStatus();

            SetCellsAliveStatus(nextTurnLivingStatus);
        }

        private Cell[][] GenerateEmptyWorld(int width, int height, Percentage percentage)
        {
            var random = new Random();
            var cellGrid = new Cell[width][];
            for (var cellColumnIndex = 0; cellColumnIndex < width; cellColumnIndex++)
            {
                cellGrid[cellColumnIndex] = new Cell[height];
                for (var cellRowIndex = 0; cellRowIndex < height; cellRowIndex++)
                {
                    cellGrid[cellColumnIndex][cellRowIndex] = new Cell()
                    {
                        IsAlive = GenerateIsAlive(percentage, random)
                    };
                }
            }
            SetNeighbors(cellGrid);
            
            return cellGrid;
        }

        private void SetNeighbors(Cell[][] cellGrid)
        {
            for (var widthIndex = 0; widthIndex < cellGrid.Length; widthIndex++)
            {
                var cellColumn = cellGrid[widthIndex];
                for (var heightIndex = 0; heightIndex < cellColumn.Length; heightIndex++)
                {
                    var cell = cellColumn[heightIndex];
                    cell.Neighbors = GetNeighbors(widthIndex, heightIndex, cellGrid);
                }
            }
        }

        private IEnumerable<Cell> GetNeighbors(int widthIndex, int heightIndex, Cell[][] cellGrid)
        {
            var neighbors = new List<Cell>();
            
            for (var cellColumnIndex = widthIndex - 1; cellColumnIndex < widthIndex + 2; cellColumnIndex++) {
                for (var cellRowIndex = heightIndex - 1; cellRowIndex < heightIndex + 2; cellRowIndex++) {
                    if (!((cellColumnIndex < 0 || cellRowIndex < 0) || (cellColumnIndex >= Width || cellRowIndex >= Height)))
                    {
                        if (cellColumnIndex != widthIndex || cellRowIndex != heightIndex) neighbors.Add(cellGrid[cellColumnIndex][cellRowIndex]);
                    }
                }
            }

            return neighbors;
        }

        private static bool GenerateIsAlive(Percentage percentage, Random random)
        {
            var isAliveInt = 1;
            if (percentage.Value != 0)
            {
                isAliveInt = random.Next(0, 100 / percentage.Value);
            }

            var isAlive = isAliveInt == 0;
            return isAlive;
        }

        public bool Equals(World other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CellGrid.SelectMany( a => a ).OrderBy( v => v ).
                SequenceEqual( other.CellGrid.SelectMany( a => a ).OrderBy( v => v ) ) 
                   && Height == other.Height && Width == other.Width;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((World) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CellGrid, Width, Height);
        }

       

        private List<bool> GetCellsNextTurnAliveStatus()
        {
            var nextTurnLivingStatus = new List<bool>();
            for (var widthIndex = 0; widthIndex < CellGrid.Length; widthIndex++)
            {
                var cellColumn = CellGrid[widthIndex];
                for (var heightIndex = 0; heightIndex < cellColumn.Length; heightIndex++)
                {
                    var cell = cellColumn[heightIndex];
                    nextTurnLivingStatus.Add(cell.IsAliveNextTurn);
                }
            }

            return nextTurnLivingStatus;
        }

        private void SetCellsAliveStatus(List<bool> nextTurnLivingStatus)
        {
            var nextTurnLivingStatusIndex = 0;
            for (var widthIndex = 0; widthIndex < CellGrid.Length; widthIndex++)
            {
                var cellColumn = CellGrid[widthIndex];
                for (var heightIndex = 0; heightIndex < cellColumn.Length; heightIndex++)
                {
                    var cell = cellColumn[heightIndex];
                    cell.IsAlive = nextTurnLivingStatus[nextTurnLivingStatusIndex];
                    nextTurnLivingStatusIndex++;
                }
            }
        }
    }
}