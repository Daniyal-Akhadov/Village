using System;
using UnityEngine;

namespace Village.Environment
{
    public class Finish : MonoBehaviour
    {
        private LeverArm _leverArm;
        private bool _isActive;

        private event Action Reached;

        private void Awake()
        {
            _leverArm = FindObjectOfType<LeverArm>();
        }

        private void OnEnable()
        {
            _leverArm.Activated += OnLeverArmActivated;
        }

        private void OnDisable()
        {
            _leverArm.Activated -= OnLeverArmActivated;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_isActive == true && col.TryGetComponent(out Hero.HeroInput _))
            {
                Reached?.Invoke();
            }
        }

        private void OnLeverArmActivated()
        {
            _isActive = true;
        }
    }
}