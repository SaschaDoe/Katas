namespace GameOfLifeOOP.IO
{
    public interface IWorldOutputGenerator
    {
        string WorldToString(int xPosition, int yPosition, int width, int height);
    }
}