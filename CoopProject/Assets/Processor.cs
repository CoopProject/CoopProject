using System;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private ProductPanel _panel;
    [SerializeField] private float _duration = 5f;

    private int _�ountTransformation = 0;
    private int _�ompleted = 0;
    private float _countDuration = 0;
    private float _durationMinimum = 2.5f;
    private float _maxDurationVelue => _duration;
    public event Action Done; 

    public int CountTransformation => _�ountTransformation;
    public int Completed => _�ompleted;


    private void FixedUpdate()
    {
        if (_�ountTransformation != 0)
        {
            _countDuration -= Time.deltaTime;
            
            if (_countDuration <= 0)
            {
                _countDuration = _maxDurationVelue;
                Transformation();
            }
        }
    }

    public void Conversion()=> _�ountTransformation++;

    public void AddAll(int value) => _�ountTransformation += value;
    

    public void CancellationProcessing() => _�ountTransformation--;
    

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

    public void LevelUp()
    {
        if (_duration > _durationMinimum)
            _duration -= 0.5f;
    }
}
