using QuizNumbersLetters.Particles.Interfaces;
using UnityEngine;

namespace QuizNumbersLetters.Particles
{
    public class ParticleFactory : IParticleFactory
    {
        private readonly GameObject _particlePrefab;
        
        public ParticleFactory(GameObject particlePrefab)
        {
            _particlePrefab = particlePrefab;
        }

        public void CreateParticle(Vector3 position)
        {
            var particleGameObject = Object.Instantiate(_particlePrefab);
            particleGameObject.transform.position = position;
        }
    }
}