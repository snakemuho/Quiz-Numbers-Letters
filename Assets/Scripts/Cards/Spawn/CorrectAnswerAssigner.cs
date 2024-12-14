using System;
using System.Collections.Generic;
using QuizNumbersLetters.Cards.Progress.Interfaces;
using QuizNumbersLetters.Cards.Spawn.Interfaces;
using QuizNumbersLetters.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace QuizNumbersLetters.Cards.Spawn
{
    public class CorrectAnswerAssigner : ICorrectAnswerAssigner
    {
        private readonly QuestionDisplay _questionDisplay;
        private readonly IUsedCardsTracker _usedCardsTracker;
        private readonly List<Card> _unusedCards = new List<Card>();

        public CorrectAnswerAssigner(QuestionDisplay questionDisplay, IUsedCardsTracker usedCardsTracker)
        {
            _questionDisplay = questionDisplay;
            _usedCardsTracker = usedCardsTracker;
        }

        public void AssignCorrectAnswer(List<Card> spawnedCards, Action correctAnswerAction)
        {
            if (spawnedCards.Count == 0)
            {
                Debug.LogError("No cards to assign as the correct answer.");
                return;
            }

            Card correctCard = null;
            _unusedCards.Clear();

            foreach (var card in spawnedCards)
            {
                if (!_usedCardsTracker.WasCardUsed(card.CardData.Identifier))
                    _unusedCards.Add(card);
            }

            if (_unusedCards.Count > 0)
            {
                correctCard = _unusedCards[Random.Range(0, _unusedCards.Count)];
            }
            else
            {
                correctCard = spawnedCards[Random.Range(0, spawnedCards.Count)];
                
                _usedCardsTracker.ResetUsedCards();
            }

            correctCard.MarkAsCorrectAnswer(correctAnswerAction);
            _usedCardsTracker.MarkCardAsUsed(correctCard.CardData.Identifier);
            _questionDisplay.SetText(correctCard.CardData.Identifier);
        }
    }
}