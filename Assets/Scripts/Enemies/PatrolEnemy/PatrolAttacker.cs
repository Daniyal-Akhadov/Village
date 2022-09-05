using UnityEngine;
using Village.Hero;

namespace Village.Enemies
{
    public class PatrolAttacker : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        private bool _isAttack;

        private void OnCollisionStay2D(Collision2D col)
        {
            if (_isAttack == false && col.gameObject.TryGetComponent(out HeroHealth hero))
            {
                _isAttack = true;
                hero.ApplyDamage(_damage);
                Invoke(nameof(StopAttack), 1f);
            }
        }

        private void StopAttack()
        {
            _isAttack = false;
        }
    }
}