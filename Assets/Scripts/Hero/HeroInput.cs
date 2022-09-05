using System;
using UnityEngine;

namespace Village.Hero
{
    [RequireComponent(typeof(HeroMovement))]
    [RequireComponent(typeof(HeroJumper))]
    [RequireComponent(typeof(HeroAttacker))]
    [RequireComponent(typeof(HeroHealth))]
    public class HeroInput : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joystick;

        private HeroMovement _movement;
        private HeroJumper _jumper;
        private HeroAttacker _attacker;
        private HeroHealth _health;
        private float _direction;
        private bool _isInteractable;

        private const string HorizontalAxis = "Horizontal";

        private void Awake()
        {
            _movement = GetComponent<HeroMovement>();
            _jumper = GetComponent<HeroJumper>();
            _attacker = GetComponent<HeroAttacker>();
            _health = GetComponent<HeroHealth>();
            _isInteractable = true;
        }

        private void OnEnable()
        {
            _health.Died += OnHeroDied;
        }

        private void OnDisable()
        {
            _health.Died -= OnHeroDied;
        }

        private void Update()
        {
            if (_isInteractable == false)
                return;

            _direction = _joystick.Horizontal;

#if UNITY_STANDALONE || UNITY_WEBPLAYER
            // _direction = Input.GetAxis(HorizontalAxis);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                _jumper.TryJump();
            }

            if (Input.GetMouseButtonDown(0))
            {
                _attacker.TryAttack();
            }

            if (Input.GetMouseButtonDown(1))
            {
                _health.Defend();
            }

            if (Input.GetMouseButtonUp(1))
            {
                _health.StopDefend();
            }
#endif
        }

        private void FixedUpdate()
        {
            _movement.Move(_direction);
        }

        private void OnHeroDied()
        {
            _isInteractable = false;
        }
    }
}