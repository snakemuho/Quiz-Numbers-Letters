using System.Collections.Generic;
using QuizNumbersLetters.Cards.Data;

namespace QuizNumbersLetters.Cards.Progress.Interfaces
{
    public interface IUsedCardsTracker
    {
        bool WasCardUsed(string identifier);
        void MarkCardAsUsed(string cardDataIdentifier);
        void ResetUsedCards();
        void SetPrioritizedCardIndexes(CardData[] cardDataPool);
        int GetPrioritizedCardIndex();
    }
}