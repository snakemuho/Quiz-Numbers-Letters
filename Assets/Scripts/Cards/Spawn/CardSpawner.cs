using System.Collections.Generic;
using System.Linq;
using QuizNumbersLetters.Cards.Data;
using QuizNumbersLetters.Cards.Progress.Interfaces;
using QuizNumbersLetters.Cards.Spawn.Interfaces;
using QuizNumbersLetters.Grid;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace QuizNumbersLetters.Cards.Spawn
{
    public class CardSpawner : MonoBehaviour
    {
        [SerializeField] private CardBundleData[] _cardBundles;

        private readonly List<Card> _spawnedCards = new List<Card>();

        private ICardFactory _cardFactory;
        private ILevelProgressTracker _levelProgressTracker;
        private IGridGenerator _gridGenerator;
        private IUsedCardsTracker _usedCardsTracker;
        private ICorrectAnswerAssigner _correctAnswerAssigner;
        
        [Inject]
        public void Construct(ICardFactory cardFactory, ILevelProgressTracker levelProgressTracker, IGridGenerator gridGenerator, 
            IUsedCardsTracker usedCardsTracker, ICorrectAnswerAssigner correctAnswerAssigner)
        {
            _cardFactory = cardFactory;
            _levelProgressTracker = levelProgressTracker;
            _gridGenerator = gridGenerator;
            _usedCardsTracker = usedCardsTracker;
            _correctAnswerAssigner = correctAnswerAssigner;
        }

        public void SpawnNewCards()
        {
            var gridDifficulty = _levelProgressTracker.GetCurrentGridDifficulty();
            if (gridDifficulty == null) 
                return;
            
            ClearExistingCards();

            var cardBundle = GetRandomCardBundle();
            var gridPositions = _gridGenerator.GenerateGridPositions(gridDifficulty.Rows, gridDifficulty.Columns);

            SpawnCards(cardBundle, gridPositions);

            _correctAnswerAssigner.AssignCorrectAnswer(_spawnedCards, SpawnNewCards);
            _levelProgressTracker.IncreaseIndex();
        }

        public void BounceNewCards()
        {
            foreach (var card in _spawnedCards)
            {
                card.BounceIcon();
            }
        }

        private void ClearExistingCards()
        {
            if (_spawnedCards.Count > 0)
            {
                foreach (var card in _spawnedCards)
                {
                    Destroy(card.gameObject);
                }

                _spawnedCards.Clear();
            }
        }
        
        private CardBundleData GetRandomCardBundle()
        {
            return _cardBundles[Random.Range(0, _cardBundles.Length)];
        }
        
        private void SpawnCards(CardBundleData cardBundle, IEnumerable<Vector2> gridPositions)
        {
            var prioritizedIndexes = _usedCardsTracker.GetPrioritizedCardIndexes(cardBundle.CardData).ToList();

            foreach (var position in gridPositions)
            {
                var cardIndex = prioritizedIndexes[Random.Range(0, prioritizedIndexes.Count)];
                prioritizedIndexes.Remove(cardIndex);
                
                var cardData = cardBundle.CardData[cardIndex];
                var card = _cardFactory.CreateCard(cardData, position);
                _spawnedCards.Add(card);
            }
        }
    }
}