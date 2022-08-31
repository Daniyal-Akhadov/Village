using UnityEngine;

namespace Village.Enemies
{
    [RequireComponent(typeof(PatrolEnemy))]
    public class EnemyVision : MonoBehaviour
    {
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private Vector2 _direction = Vector2.right;
        private float _hitDistance;
        private Vector2 _origin;
        private PatrolEnemy _patrolEnemy;

        private void Awake()
        {
            _patrolEnemy = GetComponent<PatrolEnemy>();
        }

        private void Update()
        {
            _origin = transform.position;
            DefineDirection();
            var hit = Physics2D.CircleCast(transform.position, _radius, _direction, _maxDistance, _layerMask);

            if (hit)
            {
                _hitDistance = hit.distance;
                _patrolEnemy.StartChasing();
            }
            else
                _hitDistance = _maxDistance;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_origin, _origin + _direction * _hitDistance);
            Gizmos.DrawWireSphere(_origin + _direction * _hitDistance, _radius);
        }

        private void DefineDirection()
        {
            _direction = _patrolEnemy.IsFacingRight ? Vector2.right : Vector2.left;
        }
    }
}