using System;
using UnityEngine;
using Village.Environment.Tag;

namespace Village.Hero
{
    public class HeroJumper : MonoBehaviour
    {
        private const float MIN_ANGLE_FOR_JUMPING = 45f;
        [SerializeField] private float _force = 150f;
        [SerializeField] private AudioSource _jumpSound;

        private Rigidbody2D _rigidbody;
        private bool _isGround;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            foreach (var contact in collision.contacts)
            {
                float angle = Vector3.Angle(contact.normal, Vector3.up);

                if (angle < MIN_ANGLE_FOR_JUMPING)
                {
                    _isGround = true;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _isGround = false;
        }

        public void TryJump()
        {
            if (_isGround == false)
                return;

            _jumpSound.Play();
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }
}