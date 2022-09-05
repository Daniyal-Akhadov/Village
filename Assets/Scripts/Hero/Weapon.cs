using UnityEngine;
using Village.Enemies;

namespace Village.Hero
{
    [RequireComponent(typeof(Collider2D))]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private AudioSource _hitSound;

        private Collider2D _collider;
        private bool _isActive;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (_isActive == true && col.TryGetComponent(out IDamageable iDamageable))
            {
                _hitSound.Play();
                iDamageable.ApplyDamage(_damage);
                Deactivate();
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

        public void Release()
        {
            gameObject.AddComponent<Rigidbody2D>().AddTorque(5f, ForceMode2D.Impulse);
            _collider.isTrigger = false;
            transform.parent = null;
        }
    }
}