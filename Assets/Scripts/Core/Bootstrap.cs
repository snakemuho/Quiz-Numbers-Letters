using QuizNumbersLetters.Cards.Progress.Interfaces;
using QuizNumbersLetters.Cards.Spawn;
using QuizNumbersLetters.Grid;
using QuizNumbersLetters.Grid.Data;
using QuizNumbersLetters.UI;
using UnityEngine;
using VContainer;

namespace QuizNumbersLetters.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Vector2 _gridCellSize;
        [SerializeField] private Vector2 _gridCellSpacing;
        [SerializeField] private GameObject _gridBackground;
        [SerializeField] private GridDifficultyData[] _gridDifficultyDatas;
        [SerializeField] private CardSpawner _cardSpawner;
        [SerializeField] private GameObject _restartPanel;

        private IGridGenerator _gridGenerator;
        private ILevelProgressTracker _levelProgressTracker;
        private ILevelRestart _levelRestart;
        private QuestionDisplay _questionDisplay;
        
        [Inject]
        private void Construct(ILevelProgressTracker levelProgressTracker, ILevelRestart levelRestart,
            IGridGenerator gridGenerator, QuestionDisplay questionDisplay)
        {
            _levelProgressTracker = levelProgressTracker;
            _levelRestart = levelRestart;
            _gridGenerator = gridGenerator;
            _questionDisplay = questionDisplay;
        }

        private void Start()
        {
            _levelProgressTracker.SetGridDifficulties(_gridDifficultyDatas);
            _gridGenerator.SetGridData(_gridBackground, _gridCellSize, _gridCellSpacing);
            _levelRestart.SetRestartObjects(_restartPanel, _questionDisplay, _cardSpawner);

            _levelRestart.RestartGame();
        }
    }
}