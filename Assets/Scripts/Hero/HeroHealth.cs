using System;
using UnityEngine;
using UnityEngine.UI;
using Village.Enemies;

namespace Village.Hero
{
    public class HeroHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private int _health = 5;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _slider.maxValue = _health;
            _slider.value = _health;
        }

        public void ApplyDamage(int value)
        {
            _health -= value;
            _animator.SetTrigger(HeroAnimations.Hit);
            _slider.value = _health;

            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _animator.SetTrigger(HeroAnimations.Dead);
        }
    }
}