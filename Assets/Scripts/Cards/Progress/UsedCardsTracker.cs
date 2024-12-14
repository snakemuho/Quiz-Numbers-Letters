using System.Collections.Generic;
using QuizNumbersLetters.Cards.Data;
using QuizNumbersLetters.Cards.Progress.Interfaces;

namespace QuizNumbersLetters.Cards.Progress
{
    public class UsedCardsTracker : IUsedCardsTracker
    {
        private readonly HashSet<string> _usedCards = new HashSet<string>();
        private readonly List<int> _usedIndexes = new List<int>();
        private readonly List<int> _unusedIndexes = new List<int>();

        public bool WasCardUsed(string identifier)
        {
            return _usedCards.Contains(identifier);
        }

        public void MarkCardAsUsed(string identifier)
        {
            _usedCards.Add(identifier);
        }

        public (List<int> unusedIndexes, List<int> usedIndexes) GetPrioritizedCardIndexes(CardData[] cardDataPool)
        {
            _usedIndexes.Clear();
            _unusedIndexes.Clear();

            for (int i = 0; i < cardDataPool.Length; i++)
            {
                if (WasCardUsed(cardDataPool[i].Identifier))
                    _usedIndexes.Add(i);
                else
                    _unusedIndexes.Add(i);
            }

            return (_unusedIndexes, _usedIndexes);
        }

        public void ResetUsedCards()
        {
            _usedCards.Clear();
        }
    }
}