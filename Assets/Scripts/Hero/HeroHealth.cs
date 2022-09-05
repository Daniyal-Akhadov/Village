using System;
using UnityEngine;
using UnityEngine.UI;
using Village.Enemies;

namespace Village.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private int _health = 5;
        [SerializeField] private AudioSource _hitSound;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Shield _shield;

        private float _getDamageTimer;
        private bool _isActive;
        private bool _isDied;
        private bool _isDefended;
        private Animator _animator;
        private Rigidbody2D _rigidbody;

        public event Action Died;

        private const float TIME_TO_GET_DAMAGE = 0.8f;
        public bool IsDied => _isDied;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _slider.maxValue = _health;
            _slider.value = _health;
        }

        private void Update()
        {
            if (_isActive == true)
                return;

            _getDamageTimer += Time.deltaTime;

            if (TIME_TO_GET_DAMAGE < _getDamageTimer)
            {
                _getDamageTimer = 0f;
                _isActive = true;
            }
        }

        public void Defend()
        {
            _isDefended = true;
            _animator.SetBool(HeroAnimations.Defend, _isDefended);
        }

        public void StopDefend()
        {
            _isDefended = false;
            _animator.SetBool(HeroAnimations.Defend, _isDefended);
        }

        public void ApplyDamage(int value)
        {
            if (_isDied == true || _isActive == false || _isDefended == true)
                return;

            _isActive = false;
            _health -= value;
            _slider.value = _health;

            _animator.SetTrigger(HeroAnimations.Hit);
            _hitSound.Play();

            if (_health <= 0)
            {
                FreeHands();
                Die();
                _rigidbody.velocity = Vector2.zero;
            }
        }

        private void Die()
        {
            _isDied = true;
            _animator.SetTrigger(HeroAnimations.Dead);
            _slider.gameObject.SetActive(false);
            Died?.Invoke();
        }

        private void FreeHands()
        {
            _shield.Release();
            _weapon.Release();
        }
    }
}