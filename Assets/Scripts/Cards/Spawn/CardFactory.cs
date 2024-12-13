using QuizNumbersLetters.Cards.Data;
using QuizNumbersLetters.Cards.Spawn.Interfaces;
using QuizNumbersLetters.Particles.Interfaces;
using UnityEngine;

namespace QuizNumbersLetters.Cards.Spawn
{
    public class CardFactory : ICardFactory
    {
        private readonly GameObject _cardPrefab;
        private readonly IParticleFactory _particleFactory;

        public CardFactory(GameObject cardPrefab, IParticleFactory particleFactory)
        {
            _cardPrefab = cardPrefab;
            _particleFactory = particleFactory;
        }

        public Card CreateCard(CardData cardData, Vector2 position)
        {
            var cardGameObject = Object.Instantiate(_cardPrefab);
            Card card = cardGameObject.GetComponent<Card>();
            
            cardGameObject.transform.position = position;
            if (cardData.ShouldStartRotated)
            {
                cardGameObject.transform.GetChild(0).Rotate(0, 0, cardData.DegreesToRotate);
            }

            card.Initialize(cardData, _particleFactory);
            return card;
        }
    }
}