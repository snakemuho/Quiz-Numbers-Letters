using QuizNumbersLetters.Cards.Spawn;
using QuizNumbersLetters.UI;
using UnityEngine;

namespace QuizNumbersLetters.Cards.Progress.Interfaces
{
    public interface ILevelRestart
    {
        void SetRestartObjects(GameObject restartPanel, QuestionDisplay questionDisplay,
            CardSpawner cardSpawner);
        void ShowRestartPanel();
        void RestartGame();
    }
}