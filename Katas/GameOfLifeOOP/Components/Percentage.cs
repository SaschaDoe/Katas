using System;

namespace GameOfLifeOOP.Components
{
    public class Percentage
    {
        
        
        public Percentage(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(Percentage)} must not be smaller than 0");
            } 
            if (value > 100)
            {
                throw new ArgumentException($"{nameof(Percentage)} must not be greater than 100");
            }
            Value = value;
        }

        public int Value { get; init; }
    }
}