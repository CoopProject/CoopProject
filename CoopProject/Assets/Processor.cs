using System;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private ProductPanel _panel;
    [SerializeField] private float _duration = 5f;
    [SerializeField] private GameData _data;
    [SerializeField] private string _keyDataConvertion;
    [SerializeField] private string _keyDataComplited;

    private int _�ountTransformation = 0;
    private int _�ompleted = 0;
    private float _countDuration = 5f;
    private float _durationMinimum = 2.5f;
    private float _maxDurationVelue => _duration;
    
    public event Action Done;
    public int CountTransformation => _�ountTransformation;
    public int Completed => _�ompleted;

    private void Awake()
    {
        LoadData();
    }
    
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

    public void Conversion()
    {
        _�ountTransformation++;
        SaveData();
    }

    public void AddAll(int value)
    {
        _�ountTransformation += value;
        SaveData();
    }


    public void CancellationProcessing()
    {
        _�ountTransformation--;
        SaveData();
    }

    public void Reset()=> _�ompleted = 0;

    public void LevelUp()
    {
        if (_duration > _durationMinimum)
            _duration -= 0.5f;
        
        SaveData();
    }

    public void LevelUpReward()
    {
        if (_duration > _durationMinimum)
            _duration -= 1f;
        
        SaveData();
    }
    
    private void Transformation()
    {
        if (_�ountTransformation >= 0)
        {
            _�ountTransformation--;
            _�ompleted++;
            Done?.Invoke();
            SaveData();
        }
        else
        {
            _�ountTransformation = 0;
            Done?.Invoke();
            SaveData();
        }
    }


    private void SaveData()
    {
        _data.Save(_keyDataConvertion,_�ountTransformation);
        _data.Save(_keyDataComplited,_�ompleted);
        PlayerPrefs.SetFloat("duration",_countDuration);
    }

    private void LoadData()
    {
        _�ountTransformation =  _data.Load(_keyDataConvertion);
        _�ompleted = _data.Load(_keyDataComplited);
        PlayerPrefs.GetFloat("duration", 0);
    }
}
