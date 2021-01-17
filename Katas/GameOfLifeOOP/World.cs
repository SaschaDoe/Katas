using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using GameOfLifeOOP;

namespace GameConsole
{
    public class World : IEquatable<World>
    {
        public Cell[][] CellGrid { get; }
        public int Width { get; }
        public int Height { get; }

        public World(int width, int height, Percentage percentage)
        {
            Width = width;
            Height = height;
            CellGrid = GenerateEmptyWorld(width, height, percentage);
            
        }

        public World(Cell[][] cellGrid)
        {
            Width = cellGrid.Length;
            Height = cellGrid[0].Length;
            CellGrid = cellGrid;
        }

        private Cell[][] GenerateEmptyWorld(int width, int height, Percentage percentage)
        {
            var random = new Random();
            var cellGrid = new Cell[width][];
            for (var i = 0; i < width; i++)
            {
                cellGrid[i] = new Cell[height];
                for (var j = 0; j < height; j++)
                {
                    cellGrid[i][j] = new Cell()
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
            
            for (int i = widthIndex - 1; i < widthIndex + 2; i++) {
                for (int j = heightIndex - 1; j < heightIndex + 2; j++) {
                    if (!((i < 0 || j < 0) || (i >= Width || j >= Height)))
                    {
                        if (i != widthIndex || j != heightIndex) neighbors.Add(cellGrid[i][j]);
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

        public void NextTurn()
        {
            var nextTurnLivingStatus = GetCellsNextTurnAliveStatus();

            SetCellsAliveStatus(nextTurnLivingStatus);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (var widthIndex = 0; widthIndex < CellGrid.Length; widthIndex++)
            {
                var cellColumn = CellGrid[widthIndex];
                for (var heightIndex = 0; heightIndex < cellColumn.Length; heightIndex++)
                {
                    var cell = cellColumn[heightIndex];
                    stringBuilder.Append(cell);
                }

                if (widthIndex < CellGrid.Length - 1)
                {
                    stringBuilder.Append(Environment.NewLine);
                }
                
            }

            return stringBuilder.ToString();
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