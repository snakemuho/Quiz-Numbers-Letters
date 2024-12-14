using QuizNumbersLetters.Cards.Spawn;
using QuizNumbersLetters.Progress.Interfaces;
using QuizNumbersLetters.UI;
using UnityEngine;

namespace QuizNumbersLetters.Progress
{
    public class GameRestartHandler : IGameRestartHandler
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