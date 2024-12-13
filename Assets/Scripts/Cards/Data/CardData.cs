using System;
using UnityEngine;

namespace QuizNumbersLetters.Cards.Data
{
    [Serializable]
    public class CardData
    {
        [SerializeField] 
        private string _identifier;
        
        [SerializeField] 
        private Sprite _sprite;
        
        [SerializeField] 
        private bool _shouldStartRotated;
        
        [SerializeField] 
        [Range(-180,180)]
        private int _degreesToRotate;
        
        public string Identifier => _identifier;
        
        public Sprite Sprite => _sprite;
        
        public bool ShouldStartRotated => _shouldStartRotated;
        
        public int DegreesToRotate => _degreesToRotate;
    }
}