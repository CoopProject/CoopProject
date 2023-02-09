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
    private readonly int _attack = Animator.StringToHash("Attack");
    private readonly int _extract = Animator.StringToHash("Extract");
    
    public void Move() => _animator.SetBool(_run, true);
    public void Stop() => _animator.SetBool(_run, false);

    public void Extract() => _animator.SetBool(_extract, true);
    public void StopExtract() =>_animator.SetBool(_extract, false);

}
