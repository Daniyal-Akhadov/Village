using System;
using UnityEngine;

namespace Village.Environment
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private Canvas _levelComplete;
        [SerializeField] private Canvas _advice;

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
                _levelComplete.gameObject.SetActive(true);
                Reached?.Invoke();
                Time.timeScale = 0f;
            }
        }

        private void OnLeverArmActivated()
        {
            _advice.gameObject.SetActive(false);
            _isActive = true;
        }
    }
}