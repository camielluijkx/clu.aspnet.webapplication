namespace clu.aspnet.webapplication.mvc.core.Services
{
    public interface ISquareManager
    {
        string[,] GetSquares();

        void SwapColor(int x, int y);
    }
}