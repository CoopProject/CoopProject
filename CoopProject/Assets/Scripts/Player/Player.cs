using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;

    private int _treeResourceCounter;
    private float _extractDuration = 1f;

    private void OnTriggerStay(Collider other)
    {
        _extractDuration -= Time.deltaTime;
        if (other.TryGetComponent(out Tree tree) && _extractDuration < 0)
        {
            tree.TakeDamage();
            Extract();
            _extractDuration = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _animator.StopExtract();
    }

    private void Extract()
    {
        _animator.Extract();
    }
}