using System;
using DG.Tweening;
using QuizNumbersLetters.Cards.Data;
using QuizNumbersLetters.Particles.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace QuizNumbersLetters.Cards
{
    public class Card : MonoBehaviour, IPointerClickHandler
    {
        public CardData CardData { get; private set; }

        [SerializeField] private SpriteRenderer _iconSpriteRenderer;
        [SerializeField] private bool _isCorrectAnswer;

        private bool _interactable = true;
        private Action _correctAnswerAction;
        private Sequence _shakeSequence;
        
        private IParticleFactory _particleFactory;

        public void Initialize(CardData cardData, IParticleFactory particleFactory)
        {
            CardData = cardData;
            _iconSpriteRenderer.sprite = CardData.Sprite;
            _particleFactory = particleFactory;
        }

        public void MarkAsCorrectAnswer(Action correctAnswerAction)
        {
            _isCorrectAnswer = true;
            _correctAnswerAction += correctAnswerAction;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_interactable) return;
            if (_isCorrectAnswer)
            {
                _interactable = false;
                _particleFactory.CreateParticle(transform.position + Vector3.back);
                BounceIcon(() => _correctAnswerAction?.Invoke());
            }
            else
            {
                _interactable = false;
                ShakeIcon();
            }
        }

        public void BounceIcon(Action onBounceComplete = null)
        {
            _iconSpriteRenderer.transform.localScale *= 0.5f;
            _iconSpriteRenderer.transform.DOScale(Vector3.one * 0.5f, 0.5f).SetEase(Ease.OutBounce)
                .OnComplete(() => onBounceComplete?.Invoke());
        }

        private void ShakeIcon()
        {
            _shakeSequence.Kill();
            _iconSpriteRenderer.transform.localPosition = Vector3.zero;
            _shakeSequence = DOTween.Sequence()
                .Append(_iconSpriteRenderer.transform.DOLocalMoveX(-0.12f, 0.1f))
                .Append(_iconSpriteRenderer.transform.DOLocalMoveX(0.1f, 0.4f))
                .Append(_iconSpriteRenderer.transform.DOLocalMoveX(0, 0.2f)).SetEase(Ease.OutBounce)
                .OnComplete(() => _interactable = true);
        }
    }
}