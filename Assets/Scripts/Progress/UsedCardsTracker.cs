using System.Collections.Generic;
using QuizNumbersLetters.Cards.Data;
using QuizNumbersLetters.Progress.Interfaces;
using UnityEngine;

namespace QuizNumbersLetters.Progress
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

        public void SetPrioritizedCardIndexes(CardData[] cardDataPool)
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
        }

        public int GetPrioritizedCardIndex()
        {
            if (_unusedIndexes.Count > 0)
            {
                return GetRandomIndex(_unusedIndexes);
            }
            else if (_usedIndexes.Count > 0)
            {
                return GetRandomIndex(_usedIndexes);
            }
            else
            {
                Debug.LogError("Not enough cards to fill the grid.");
                return 0;
            }
        }

        public void ResetUsedCards()
        {
            _usedCards.Clear();
        }

        private int GetRandomIndex(List<int> list)
        {
            int randomIndex = Random.Range(0, list.Count);
            int cardIndex = list[randomIndex];
            list.RemoveAt(randomIndex);
            return cardIndex;
        }
    }
}