using UnityEngine;

namespace Village.Hero
{
    public static class HeroAnimations
    {
        public static readonly int HorizontalSpeed = Animator.StringToHash("HorizontalSpeed");
        public static readonly int SimpleAttack = Animator.StringToHash("SimpleAttack");
        public static readonly int SuperAttack = Animator.StringToHash("SuperAttack");
        public static readonly int Dead = Animator.StringToHash("Dead");
        public static readonly int Hit = Animator.StringToHash("Hit");
    }
}