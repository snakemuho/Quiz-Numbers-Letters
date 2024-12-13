using UnityEngine;

namespace QuizNumbersLetters.Cards.Data
{
    [CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 10)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField]
        private CardData[] _cardData;

        public CardData[] CardData => _cardData;
    }
}