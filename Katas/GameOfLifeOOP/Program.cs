using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameOfLifeOOP.Components;

namespace GameOfLifeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new World(20, 100, new Percentage(50));
            while (true)
            {
                Console.Write(world);
                world.NextTurn();
                Task.Delay(100).Wait(); 
                Console.SetCursorPosition(0,0);
            }
        }
        
       
    }
}