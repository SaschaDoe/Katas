using GameOfLifeFunctional.FunctionalBasics;

namespace GameOfLifeFunctional
{
    public static class GameOfLife
    {
        public static Optional<Board> BoardIsOfSize((int width, int height) boardSize)
        {
            var board = new Board(boardSize);
            return board;
        }
    }
}