using System;
using System.Collections;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private ProductPanel _panel;
    [SerializeField] private float _duration = 1f;

    private int _�ountTransformation = 0;
    private int _�ompleted = 0;
    private bool _iWorik = false;
    private float _countDuration = 0;
    public event Action Done; 

    public int CountTransformation => _�ountTransformation;
    public int Completed => _�ompleted;


    private void FixedUpdate()
    {
        if (_�ountTransformation != 0)
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
        _�ountTransformation++;
    }

    private void Transformation()
    {
        _�ountTransformation--;
        _�ompleted++;
        Done?.Invoke();
    }

    public void Reset()
    {
        _�ountTransformation = 0;
        _�ompleted = 0;
    }
}
