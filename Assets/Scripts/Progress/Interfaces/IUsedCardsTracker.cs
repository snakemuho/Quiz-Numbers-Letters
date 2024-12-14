using QuizNumbersLetters.Cards.Data;

namespace QuizNumbersLetters.Progress.Interfaces
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