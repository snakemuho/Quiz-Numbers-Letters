using QuizNumbersLetters.Grid.Data;
using QuizNumbersLetters.Progress.Interfaces;

namespace QuizNumbersLetters.Progress
{
    public class LevelProgressTracker : ILevelProgressTracker
    {
        private readonly IGameRestartHandler _gameRestartHandler;
        
        private GridDifficultyData[] _gridDifficultyDatas;
        private int _currentGridDifficultyIndex;

        public LevelProgressTracker(IGameRestartHandler gameRestartHandler)
        {
            _gameRestartHandler = gameRestartHandler;
        }

        public void SetGridDifficulties(GridDifficultyData[] gridDifficultyDatas)
        {
            _gridDifficultyDatas = gridDifficultyDatas;
        }

        public GridDifficultyData GetCurrentGridDifficulty()
        {
            if (_currentGridDifficultyIndex >= _gridDifficultyDatas.Length)
            {
                ResetIndex();
                _gameRestartHandler.ShowRestartPanel();
                return null;
            }
            return _gridDifficultyDatas[_currentGridDifficultyIndex];
        }

        public void IncreaseIndex()
        {
            _currentGridDifficultyIndex++;
        }

        private void ResetIndex()
        {
            _currentGridDifficultyIndex = 0;
        }
    }
}