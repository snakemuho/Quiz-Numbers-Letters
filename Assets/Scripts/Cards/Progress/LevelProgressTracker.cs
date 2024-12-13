using QuizNumbersLetters.Cards.Progress.Interfaces;
using QuizNumbersLetters.Grid.Data;

namespace QuizNumbersLetters.Cards.Progress
{
    public class LevelProgressTracker : ILevelProgressTracker
    {
        private readonly ILevelRestart _levelRestart;
        
        private GridDifficultyData[] _gridDifficultyDatas;
        private int _currentGridDifficultyIndex;

        public LevelProgressTracker(ILevelRestart levelRestart)
        {
            _levelRestart = levelRestart;
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
                _levelRestart.ShowRestartPanel();
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