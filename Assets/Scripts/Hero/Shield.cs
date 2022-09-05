using UnityEngine;

namespace Village.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Shield : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Release()
        {
            _rigidbody.isKinematic = false;
            _collider.isTrigger = false;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}