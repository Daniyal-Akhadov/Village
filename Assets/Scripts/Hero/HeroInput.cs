using System;
using UnityEngine;


namespace Village.Hero
{
    [RequireComponent(typeof(HeroMovement))]
    [RequireComponent(typeof(HeroJumper))]
    public class HeroInput : MonoBehaviour
    {
        private HeroMovement _movement;
        private HeroJumper _jumper;
        private HeroAttacker _attacker;
        private float _direction;

        private const string HorizontalAxis = "Horizontal";

        private void Awake()
        {
            _movement = GetComponent<HeroMovement>();
            _jumper = GetComponent<HeroJumper>();
            _attacker = GetComponent<HeroAttacker>();
        }

        private void Update()
        {
            _direction = Input.GetAxis(HorizontalAxis);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                _jumper.TryJump();
            }

            if (Input.GetMouseButtonDown(0))
            {
                _attacker.TryAttack();
            }
        }

        private void FixedUpdate()
        {
            _movement.Move(_direction);
        }
    }
}