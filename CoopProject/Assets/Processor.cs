using System;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private ProductPanel _panel;
    [SerializeField] private float _duration = 5f;
    [SerializeField] private GameData _data;
    [SerializeField] private string _keyDataConvertion;
    [SerializeField] private string _keyDataComplited;

    private int _ñountTransformation = 0;
    private int _ñompleted = 0;
    private float _countDuration = 5f;
    private float _durationMinimum = 2.5f;
    private float _maxDurationVelue => _duration;
    
    public event Action Done;
    public int CountTransformation => _ñountTransformation;
    public int Completed => _ñompleted;

    private void Awake()
    {
        LoadData();
    }
    
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

    public void Conversion()
    {
        _ñountTransformation++;
        SaveData();
    }

    public void AddAll(int value)
    {
        _ñountTransformation += value;
        SaveData();
    }


    public void CancellationProcessing()
    {
        _ñountTransformation--;
        SaveData();
    }

    public void Reset()
    {
        _ñompleted = 0;
        SaveData();
    }

    public void LevelUp()
    {
        if (_duration > _durationMinimum)
            _duration -= 0.7f;
        
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
        if (_ñountTransformation >= 0)
        {
            _ñountTransformation--;
            _ñompleted++;
            Done?.Invoke();
            SaveData();
        }
        else
        {
            _ñountTransformation = 0;
            Done?.Invoke();
            SaveData();
        }
    }


    private void SaveData()
    {
        PlayerPrefs.SetInt(_keyDataConvertion,_ñountTransformation);
        PlayerPrefs.SetInt(_keyDataComplited,_ñompleted);
        PlayerPrefs.SetFloat("duration",_countDuration);
    }

    private void LoadData()
    {
        _ñountTransformation =  PlayerPrefs.GetInt(_keyDataConvertion);
        _ñompleted = PlayerPrefs.GetInt(_keyDataComplited);
        _countDuration = PlayerPrefs.GetFloat("duration", _duration);
    }
}
