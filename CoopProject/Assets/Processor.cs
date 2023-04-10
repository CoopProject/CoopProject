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


    private void Update()
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

    public void Conversion()=> _�ountTransformation++;

    public void AddAll(int value) => _�ountTransformation = value;
    

    public void CancellationProcessing() => _�ountTransformation--;
    

    public void addStack(int stackValue)=> _�ountTransformation += stackValue;
    

    public void TakeStack(int stackValue) => _�ountTransformation -= stackValue;
    

    private void Transformation()
    {
        if (_�ountTransformation >= 0)
        {
            _�ountTransformation--;
            _�ompleted++;
            Done?.Invoke();
        }
        else
        {
            _�ountTransformation = 0;
            Done?.Invoke();
        }
    }

    public void Reset()=> _�ompleted = 0;
    
}
