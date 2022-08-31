using System;
using UnityEngine;
using Village.Hero;

namespace Village.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PatrolEnemy : Enemy
    {
        [SerializeField] private float _movementDistance = 1f;
        [SerializeField] private Transform _model;

        [Header("Speed")] [SerializeField] private float _patrolSpeed = 1f;
        [SerializeField] private float _chaseSpeed = 1f;

        [Header("Time")] [SerializeField] private float _timeToWait = 2f;
        [SerializeField] private float _timeToChasingHero = 5f;

        private Rigidbody2D _rigidbody;
        private PatrolDistance _patrolDistance;
        private Vector2 _targetPoint;
        private bool _isChasingPlayer;
        private Transform _hero;
        private float _waitTimer;
        private float _chasingTimer;
        private float _speed;

        private bool IsWait
        {
            get
            {
                float positionX = _rigidbody.position.x;
                bool isOutOfRightBoundary = IsFacingRight && positionX >= _patrolDistance.FinishPoint.x;
                bool isOutOfLeftBoundary = IsFacingRight == false && positionX <= _patrolDistance.StartPoint.x;
                return isOutOfLeftBoundary || isOutOfRightBoundary;
            }
        }

        public bool IsFacingRight { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            _hero = FindObjectOfType<HeroInput>().transform;
            _rigidbody = GetComponent<Rigidbody2D>();
            _patrolDistance.StartPoint = transform.position;
            _patrolDistance.FinishPoint = _patrolDistance.StartPoint + Vector2.right * _movementDistance;
            IsFacingRight = true;
            DefineTargetPoint();
            _speed = _patrolSpeed;
        }

        private void Update()
        {
            if (_isChasingPlayer == false && IsWait == true)
            {
                Wait();
            }
        }

        private void FixedUpdate()
        {
            if (_isChasingPlayer == true && _hero != null)
            {
                Move(_hero.position);
                Chase();

                if (_hero.position.x - transform.position.x < 0 && IsFacingRight == true ||
                    _hero.position.x - transform.position.x > 0 && IsFacingRight == false)
                {
                    Flip();
                }
            }

            if (IsWait == false && (_isChasingPlayer == false || _hero == null))
            {
                Move(_targetPoint);
                _speed = _patrolSpeed;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Weapon weapon))
            {
                StartChasing();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_patrolDistance.StartPoint, _patrolDistance.FinishPoint);
        }

        public void StartChasing()
        {
            _isChasingPlayer = true;
            _chasingTimer = 0f;
            _speed = _chaseSpeed;
        }

        private void Wait()
        {
            _waitTimer += Time.deltaTime;

            if (_waitTimer > _timeToWait)
            {
                _waitTimer = 0f;
                Flip();
                DefineTargetPoint();
            }
        }

        private void Chase()
        {
            _chasingTimer += Time.deltaTime;

            if (_chasingTimer > _timeToChasingHero)
            {
                _chasingTimer = 0f;
                _isChasingPlayer = false;
            }
        }

        private void DefineTargetPoint()
        {
            _targetPoint = IsFacingRight ? _patrolDistance.FinishPoint : _patrolDistance.StartPoint;
        }

        private void Move(Vector2 target)
        {
            float targetX = target.x;
            var currentPosition = _rigidbody.position;

            _rigidbody.position = Vector2.MoveTowards(
                currentPosition,
                new Vector2(targetX, currentPosition.y),
                Time.deltaTime * _speed
            );
        }

        private void Flip()
        {
            const float ScaleMultiplier = -1;
            IsFacingRight = !IsFacingRight;
            var scale = _model.transform.localScale;
            scale.x *= ScaleMultiplier;
            _model.transform.localScale = scale;
        }
    }

    public struct PatrolDistance
    {
        public Vector2 StartPoint;
        public Vector2 FinishPoint;
    }
}