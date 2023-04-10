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


    private void Update()
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

    public void Conversion()=> _ñountTransformation++;

    public void AddAll(int value) => _ñountTransformation = value;
    

    public void CancellationProcessing() => _ñountTransformation--;
    

    public void addStack(int stackValue)=> _ñountTransformation += stackValue;
    

    public void TakeStack(int stackValue) => _ñountTransformation -= stackValue;
    

    private void Transformation()
    {
        if (_ñountTransformation >= 0)
        {
            _ñountTransformation--;
            _ñompleted++;
            Done?.Invoke();
        }
        else
        {
            _ñountTransformation = 0;
            Done?.Invoke();
        }
    }

    public void Reset()=> _ñompleted = 0;
    
}
