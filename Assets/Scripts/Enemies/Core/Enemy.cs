using UnityEngine;
using UnityEngine.UI;

namespace Village.Enemies
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _health = 1;
        [SerializeField] private Slider _slider;

        private Animator _animator;

        protected virtual void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _slider.maxValue = _health;
            SetSlider();
        }

        public void ApplyDamage(int value)
        {
            _health -= value;
            _animator.SetTrigger(EnemyAnimations.Hit);
            SetSlider();

            if (_health <= 0)
            {
                Die();
            }
        }

        private void SetSlider()
        {
            _slider.value = _health;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}