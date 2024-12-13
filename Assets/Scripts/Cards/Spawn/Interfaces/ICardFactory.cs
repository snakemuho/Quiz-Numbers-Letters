using QuizNumbersLetters.Cards.Data;
using UnityEngine;

namespace QuizNumbersLetters.Cards.Spawn.Interfaces
{
    public interface ICardFactory
    {
        public Card CreateCard(CardData cardData, Vector2 position);
    }
}