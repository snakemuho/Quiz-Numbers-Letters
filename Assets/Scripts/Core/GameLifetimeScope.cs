using QuizNumbersLetters.Cards.Progress;
using QuizNumbersLetters.Cards.Progress.Interfaces;
using QuizNumbersLetters.Cards.Spawn;
using QuizNumbersLetters.Cards.Spawn.Interfaces;
using QuizNumbersLetters.Grid;
using QuizNumbersLetters.Particles;
using QuizNumbersLetters.Particles.Interfaces;
using QuizNumbersLetters.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace QuizNumbersLetters.Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private GameObject _particlePrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IGridGenerator, GridGenerator>(Lifetime.Singleton);
            builder.Register<ILevelProgressTracker, LevelProgressTracker>(Lifetime.Singleton);
            builder.Register<ILevelRestart, LevelRestart>(Lifetime.Singleton);
            builder.Register<IUsedCardsTracker, UsedCardsTracker>(Lifetime.Singleton);
            builder.Register<ICorrectAnswerAssigner, CorrectAnswerAssigner>(Lifetime.Singleton);
            builder.Register<IParticleFactory, ParticleFactory>(Lifetime.Singleton)
                .WithParameter(resolver => _particlePrefab);
            builder.Register<ICardFactory, CardFactory>(Lifetime.Singleton)
                .WithParameter(resolver => _cardPrefab);
            builder.RegisterComponentInHierarchy<QuestionDisplay>();
        }
    }
}
