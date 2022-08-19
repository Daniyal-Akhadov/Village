using System;
using UnityEngine;
using Village.Environment.Tag;

namespace Village.Hero
{
    public class HeroJumper : MonoBehaviour
    {
        [SerializeField] private float _force = 150f;

        private Rigidbody2D _rigidbody;
        private bool _isGround;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Ground _))
            {
                _isGround = true;
            }
        }

        public void TryJump()
        {
            if (_isGround == false)
                return;

            _isGround = false;
            _rigidbody.AddForce(Vector2.up * _force);
        }
    }
}