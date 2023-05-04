using System;
using UnityEngine;

namespace DefaultNamespace.Helper
{
    [RequireComponent(typeof(Animator))]
    public class HelperAnimator : MonoBehaviour
    {
        private Animator _animator;
        private readonly int _move = Animator.StringToHash("Move");
        private readonly int _extract = Animator.StringToHash("Extract");
        private readonly int _iExtract = Animator.StringToHash("IExtract");
        private readonly int _idle = Animator.StringToHash("Idle");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void Move() => _animator.SetBool(_move, true);
        public void StopMove() => _animator.SetBool(_move, false);

        public void Extract() => _animator.SetBool(_iExtract, true);
        public void StopExtract() =>_animator.SetBool(_iExtract, false);
    }
}