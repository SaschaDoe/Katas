using System;
using System.Text;
using GameOfLifeOOP.Components;

namespace GameOfLifeOOP.IO
{
    public class ConsoleWorldOutputGenerator : IWorldOutputGenerator
    {
        private World _world;

        public ConsoleWorldOutputGenerator(World world)
        {
            _world = world;
        }
        
        public string WorldToString(int xPosition, int yPosition, int width, int height)
        {
            var stringBuilder = new StringBuilder();
            for (var worldColumnIndex = 0; worldColumnIndex < _world.Width; worldColumnIndex++)
            {
                for (var worldRowIndex = 0; worldRowIndex < _world.Height; worldRowIndex++)
                {
                    var cell = _world.CellGrid[worldColumnIndex + xPosition][worldRowIndex + yPosition];
                    stringBuilder.Append(cell.IsAlive ? '*' : '.');
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}