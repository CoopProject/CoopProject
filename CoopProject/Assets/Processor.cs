using System;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private ProductPanel _panel;
    [SerializeField] private float _duration = 5f;

    private int _ñountTransformation = 0;
    private int _ñompleted = 0;
    private float _countDuration = 0;
    private float _durationMinimum = 2.5f;
    private float _maxDurationVelue => _duration;
    public event Action Done; 

    public int CountTransformation => _ñountTransformation;
    public int Completed => _ñompleted;


    private void FixedUpdate()
    {
        if (_ñountTransformation != 0)
        {
            _countDuration -= Time.deltaTime;
            
            if (_countDuration <= 0)
            {
                _countDuration = _maxDurationVelue;
                Transformation();
            }
        }
    }

    public void Conversion()=> _ñountTransformation++;

    public void AddAll(int value) => _ñountTransformation += value;
    

    public void CancellationProcessing() => _ñountTransformation--;
    

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

    public void LevelUp()
    {
        if (_duration > _durationMinimum)
            _duration -= 0.5f;
    }
}
