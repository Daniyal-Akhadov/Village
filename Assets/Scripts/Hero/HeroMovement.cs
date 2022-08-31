using UnityEngine;

namespace Village.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Transform _model;

        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private bool _isFacingRight = true;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
        }

        public void Move(float direction)
        {
            _rigidbody.velocity = new Vector2(direction * _speed * Time.fixedDeltaTime, _rigidbody.velocity.y);
            _animator.SetFloat(HeroAnimations.HorizontalSpeed, Mathf.Abs(direction));

            switch (_isFacingRight)
            {
                case false when direction > 0:
                case true when direction < 0:
                    Flip();
                    break;
            }
        }

        private void Flip()
        {
            const float DirectionMultiplier = -1f;

            _isFacingRight = !_isFacingRight;
            var scale = _model.localScale;
            scale.x *= DirectionMultiplier;
            _model.localScale = scale;
        }
    }
}