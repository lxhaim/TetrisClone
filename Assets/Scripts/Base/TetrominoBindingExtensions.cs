using Assets.Scripts.Core;
using Assets.Scripts.MonoBehaviors;

namespace Assets.Scripts.Base
{
    public static class TetrominoBindingExtensions
    {
        public static void BindTetrominoToSound(this ITetromino tetromino, SoundManager soundManager)
        {
            tetromino.MoveSucceed += soundManager.PlayTetrominoMoveSound;
            tetromino.MoveFailed += soundManager.PlayTetrominoMoveFailedSound;
            tetromino.Rotated += soundManager.PlayTetrominoRotateSound;
            tetromino.Landed += soundManager.PlayTetrominoLandSound;
        }

        public static void UnbindTetrominoFromSound(this ITetromino tetromino, SoundManager soundManager)
        {
            tetromino.MoveSucceed -= soundManager.PlayTetrominoMoveSound;
            tetromino.MoveFailed -= soundManager.PlayTetrominoMoveFailedSound;
            tetromino.Rotated -= soundManager.PlayTetrominoRotateSound;
            tetromino.Landed -= soundManager.PlayTetrominoLandSound;
        }
    }
}
