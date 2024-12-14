using System;
using DG.Tweening;
using QuizNumbersLetters.Progress.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace QuizNumbersLetters.UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Image BlackPanel;
        [SerializeField] private GameObject _restartPanel;
        
        private IGameRestartHandler _gameRestartHandler;

        public void RestartGame()
        {
            BlackPanel.gameObject.SetActive(true);
            FadeToBlack(() =>
            {
                DisableRestartPanel();
                _gameRestartHandler.RestartGame();
            });
        }

        [Inject]
        private void Construct(IGameRestartHandler gameRestartHandler)
        {
            _gameRestartHandler = gameRestartHandler;
        }

        private void Start()
        {
            DisableRestartPanel();
        }

        private void FadeToBlack(Action OnFadeComplete)
        {
            BlackPanel.DOFade(1, 0.5f)
                .OnComplete(() =>
                {
                    OnFadeComplete?.Invoke();
                    FadeOutOfBlack();
                });
        }

        private void FadeOutOfBlack()
        {
            BlackPanel.DOFade(0, 0.5f)
                .OnComplete(() => BlackPanel.gameObject.SetActive(false));
        }

        private void DisableRestartPanel()
        {
            _restartPanel.SetActive(false);
        }
    }
}