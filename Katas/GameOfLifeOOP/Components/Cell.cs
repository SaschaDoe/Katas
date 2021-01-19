using System;
using System.Collections.Generic;

namespace GameOfLifeOOP.Components
{
    public class Cell : IEquatable<Cell>
    {
        public bool IsAlive { get; set; }

        public IEnumerable<Cell> Neighbors { get; set; }

        public int LivingNeighborCount
        {
            get
            {
                var livingNeighborCount = 0;
                foreach (var neighbor in Neighbors)
                {
                    if (neighbor.IsAlive)
                    {
                        livingNeighborCount++;
                    }
                }

                return livingNeighborCount;
            }
        }

        public bool IsAliveNextTurn
        {
            get
            {
                if (IsAlive)
                {
                    if (LivingNeighborCount == 2 || LivingNeighborCount == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    if (LivingNeighborCount == 3)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool Equals(Cell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return IsAlive == other.IsAlive;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode()
        {
            return IsAlive.GetHashCode();
        }
    }
}