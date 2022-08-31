using UnityEngine;
using Village.Enemies;

namespace Village.Hero
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        private bool _isActive;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_isActive == true && col.TryGetComponent(out IDamageable iDamageable))
            {
                iDamageable.ApplyDamage(_damage);
            }
        }

        public void Activate()
        {
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }
    }
}