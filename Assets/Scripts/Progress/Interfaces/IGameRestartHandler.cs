using QuizNumbersLetters.Cards.Spawn;
using QuizNumbersLetters.UI;
using UnityEngine;

namespace QuizNumbersLetters.Progress.Interfaces
{
    public interface IGameRestartHandler
    {
        void SetRestartObjects(GameObject restartPanel, QuestionDisplay questionDisplay,
            CardSpawner cardSpawner);
        void ShowRestartPanel();
        void RestartGame();
    }
}