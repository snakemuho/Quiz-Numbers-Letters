using System.Collections.Generic;
using QuizNumbersLetters.Cards.Data;
using QuizNumbersLetters.Cards.Progress.Interfaces;

namespace QuizNumbersLetters.Cards.Progress
{
    public class UsedCardsTracker : IUsedCardsTracker
    {
        private readonly HashSet<string> _usedCards = new HashSet<string>();

        public bool WasCardUsed(string identifier)
        {
            return _usedCards.Contains(identifier);
        }

        public void MarkCardAsUsed(string identifier)
        {
            _usedCards.Add(identifier);
        }

        public IEnumerable<int> GetPrioritizedCardIndexes(CardData[] cardDataPool)
        {
            for (int i = 0; i < cardDataPool.Length; i++)
            {
                if (!WasCardUsed(cardDataPool[i].Identifier))
                {
                    yield return i;
                }
            }
            for (int i = 0; i < cardDataPool.Length; i++)
            {
                if (WasCardUsed(cardDataPool[i].Identifier))
                {
                    yield return i;
                }
            }
        }
    }
}