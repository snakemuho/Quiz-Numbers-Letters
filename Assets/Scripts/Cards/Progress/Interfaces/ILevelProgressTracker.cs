using QuizNumbersLetters.Grid.Data;

namespace QuizNumbersLetters.Cards.Progress.Interfaces
{
    public interface ILevelProgressTracker
    {
        void SetGridDifficulties(GridDifficultyData[] gridDifficultyDatas);
        void IncreaseIndex();
        GridDifficultyData GetCurrentGridDifficulty();
    }
}