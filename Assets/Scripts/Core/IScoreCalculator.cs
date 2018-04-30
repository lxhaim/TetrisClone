
namespace Assets.Scripts.Core
{
    public interface IScoreCalculator
    {
        int GetScoreForClearedLines(int numOfLines);
        int GetScoreForTetromino(int numOfMoves);
    }
}
