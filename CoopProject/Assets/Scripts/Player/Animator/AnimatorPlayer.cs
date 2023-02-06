using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _idle = Animator.StringToHash("Idle");
    private readonly int _move = Animator.StringToHash("Move");
    private readonly int _run = Animator.StringToHash("Run");
    
    public void Move() => _animator.SetBool(_run, true);
    public void Stop() => _animator.SetBool(_run, false);

}
