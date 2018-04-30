namespace Tetris.Core
{
    public interface IRandomProvider<out T>
    {
        T GetRandom();
    }
}
