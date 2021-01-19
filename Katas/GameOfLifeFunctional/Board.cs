using GameOfLifeFunctional.FunctionalBasics;
using static GameOfLifeFunctional.FunctionalBasics.F;

namespace GameOfLifeFunctional
{
    public class Board
    {
        public static Optional<Board> Of((int width, int height) boardSize)
            => IsValid(boardSize) 
                ? Some(new Board(boardSize)) 
                : None;
        public Board((int width, int height) boardSize)
        {
            Width = boardSize.width;
            Height = boardSize.height;
        }

        private static bool IsValid((int width, int height) boardSize)
            => boardSize.width > 1 && boardSize.height > 1;

        public int Width { get; }
        public int Height { get; }
    }
}