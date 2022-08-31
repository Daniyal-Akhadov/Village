using System;
using UnityEngine;
using Village.Hero;

namespace Village.Enemies
{
    public class PatrolAttacker : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _reboundForce = 20f;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out HeroHealth hero))
            {
                hero.ApplyDamage(_damage);
                // _rigidbody.AddForce();
            }
        }
    }
}