using UnityEngine;

namespace Village.Hero
{
    public class HeroAttacker : MonoBehaviour
    {
        [SerializeField] private AnimationClip _baseAttackAnimation;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private AudioSource _attackSound;

        private Animator _animator;
        private bool _isAttack;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void TryAttack()
        {
            if (_isAttack == true)
                return;

            print("Attack");
            _attackSound.Play();
            _animator.SetTrigger(HeroAnimations.SimpleAttack);
            _isAttack = true;
            _weapon.Activate();
            Invoke(nameof(CompleteAttack), _baseAttackAnimation.length - 0.035f);
        }

        private void CompleteAttack()
        {
            _weapon.Deactivate();
            _isAttack = false;
        }
    }
}