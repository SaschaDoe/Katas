using System;
using System.Threading.Tasks;
using GameOfLifeOOP.Components;
using GameOfLifeOOP.IO;

namespace GameOfLifeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new World(20, 100, new Percentage(50));
            var outputGenerator = new ConsoleWorldOutputGenerator(world);
            while (true)
            {
                var outputString = outputGenerator.WorldToString(0, 0, 100, 10);
                Console.Write(outputString);
                world.NextTurn();
                Task.Delay(100).Wait(); 
                Console.SetCursorPosition(0,0);
            }
        }
        
       
    }
}