using System.Collections.Generic;
using QuizNumbersLetters.Cards.Data;

namespace QuizNumbersLetters.Cards.Progress.Interfaces
{
    public interface IUsedCardsTracker
    {
        public bool WasCardUsed(string identifier);
        void MarkCardAsUsed(string cardDataIdentifier);
        public IEnumerable<int> GetPrioritizedCardIndexes(CardData[] cardDataPool);
    }
}