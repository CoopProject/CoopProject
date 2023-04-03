using System;
using System.Collections;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private ProductPanel _panel;
    [SerializeField] private float _duration = 1f;

    private int _ñountTransformation = 0;
    private int _ñompleted = 0;
    private bool _iWorik = false;
    private float _countDuration = 0;
    public event Action Done; 

    public int CountTransformation => _ñountTransformation;
    public int Completed => _ñompleted;


    private void FixedUpdate()
    {
        if (_ñountTransformation != 0)
        {
            _countDuration += Time.deltaTime;
            
            if (_countDuration >= _duration)
            {
                _countDuration = 0;
                Transformation();
            }
        }
    }

    public void Conversion()
    {
        _ñountTransformation++;
    }

    private void Transformation()
    {
        _ñountTransformation--;
        _ñompleted++;
        Done?.Invoke();
    }

    public void Reset()
    {
        _ñountTransformation = 0;
        _ñompleted = 0;
    }
}
