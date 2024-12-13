using DG.Tweening;
using TMPro;
using UnityEngine;

namespace QuizNumbersLetters.UI
{
    public class QuestionDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string identifier)
        {
            _textMeshPro.text = "Find " + identifier;
        }

        public void FadeIn()
        {
            _textMeshPro.color = Color.clear;
            _textMeshPro.DOFade(1, 1);
        }
    }
}