using System;
using UnityEngine;
using Village.Hero;

namespace Village.Environment
{
    public class LeverArm : MonoBehaviour
    {
        public event Action Activated;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out HeroInput _))
            {
                Activated?.Invoke();
            }
        }
    }
}