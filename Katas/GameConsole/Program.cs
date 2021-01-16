using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                var boolWorld = GenerateRandomBoolWorld(10,10);
                var boolWorldString = ParseBoolArrayToString(boolWorld);
                Console.Write(boolWorldString);
                Task.Delay(200).Wait(); 
                Console.Clear();
            }
        }

        private static string ParseBoolArrayToString(IEnumerable<bool[]> boolArray)
        {
            var stringBuilder = new StringBuilder();
            foreach (var column in boolArray)
            {
                foreach (var isCellTrue in column)
                {
                    stringBuilder.Append(isCellTrue ? '*' : '.');
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        private static IEnumerable<bool[]> GenerateRandomBoolWorld(int width, int height)
        {
            var random = new Random();
            var worldArray = new bool[width][];
            for (int widthIndex = 0; widthIndex < width; widthIndex++)
            {
                worldArray[widthIndex] = new bool[height];
                for (var heightIndex = 0; heightIndex < height; heightIndex++)
                {
                    var randomBoolNumber = random.Next(0, 2);
                    if (randomBoolNumber == 0)
                    {
                        worldArray[widthIndex][heightIndex] = true;
                    }
                    else
                    {
                        worldArray[widthIndex][heightIndex] = false;
                    }
                }
            }

            return worldArray;

        }
    }
}