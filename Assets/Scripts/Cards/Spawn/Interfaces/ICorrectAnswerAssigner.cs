using System;
using System.Collections.Generic;

namespace QuizNumbersLetters.Cards.Spawn.Interfaces
{
    public interface ICorrectAnswerAssigner
    {
        public void AssignCorrectAnswer(List<Card> spawnedCards, Action correctAnswerAction);
    }
}