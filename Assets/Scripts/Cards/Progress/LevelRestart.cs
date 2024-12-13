using QuizNumbersLetters.Cards.Progress.Interfaces;
using QuizNumbersLetters.Cards.Spawn;
using QuizNumbersLetters.UI;
using UnityEngine;

namespace QuizNumbersLetters.Cards.Progress
{
    public class LevelRestart : ILevelRestart
    {
        private GameObject _restartPanel;
        private QuestionDisplay _questionDisplay;
        private CardSpawner _cardSpawner;

        public void SetRestartObjects(GameObject restartPanel, QuestionDisplay questionDisplay, CardSpawner cardSpawner)
        {
            _restartPanel = restartPanel;
            _questionDisplay = questionDisplay;
            _cardSpawner = cardSpawner;
        }

        public void ShowRestartPanel()
        {
            _restartPanel.SetActive(true);
        }

        public void RestartGame()
        {
            _cardSpawner.SpawnNewCards();
            _cardSpawner.BounceNewCards();
            
            _questionDisplay.FadeIn();
        }
    }
}