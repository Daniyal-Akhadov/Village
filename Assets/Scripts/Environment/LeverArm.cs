using System;
using UnityEngine;
using Village.Hero;

namespace Village.Environment
{
    public class LeverArm : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public event Action Activated;

        private static readonly int TurnOn = Animator.StringToHash("TurnOn");

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out HeroInput _))
            {
                _animator.SetTrigger(TurnOn);
                Activated?.Invoke();
            }
        }
    }
}