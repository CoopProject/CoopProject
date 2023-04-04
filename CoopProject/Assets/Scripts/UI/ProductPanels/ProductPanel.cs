using System;
using ResourcesGame.TypeResource;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ProductPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private TextMeshProUGUI _textEndCount;
    [SerializeField] protected Button _putResource;
    [SerializeField] protected Button _putStack;
    [SerializeField] protected Button _takeStack;
    [SerializeField] protected Button _takeResource;
    [SerializeField] protected Processor _processor;
    [SerializeField] private int _stack = 10;

    protected ResourceCollector _resourceCollector;
    protected Player _player;
    
    
    private int _counter = 0;

    private void OnEnable()
    {
        _processor.Done += ConversionComplit;
    }

    private void LateUpdate()
    {
        SetData();
    }

    private void SetData()
    {
        _textCount.text = $"{_counter}";
        _textEndCount.text = $"{_processor.Completed}";   
    }

    public void ConversionComplit()
    {
        _counter--;
        if (_counter < 0)
        {
            _counter = 0;
            _textCount.text = $"{_counter}";
            _textEndCount.text = $"{_processor.Completed}";
        }
    }

    protected void AddResources<T>()
    {
        int countList = _resourceCollector.GetCountList<T>();
        
        if (_counter <= countList && countList != 0 )
        {
            _counter++;
            _resourceCollector.SellCountResource<T>(1);
            _processor.Conversion();
            _textCount.text = $"{_processor.CountTransformation}";
            _textEndCount.text = $"{_processor.Completed}";
        }
    }

    protected void SetStackCount<T>()
    {
        int countList = _resourceCollector.GetCountList<T>();

        if (countList > _stack && _counter + _stack <= countList)
        {
            _counter += _stack;
            _resourceCollector.SellCountResource<T>(_stack);
            _processor.addStack(_stack);
            _textCount.text = $"{_counter}";
            _textEndCount.text = $"{_processor.Completed}";
        }
    }

    protected void Take()
    {
        if (_counter + _stack <= 0)
        {
            _counter -= _stack;
            _processor.TakeStack(_stack);
            _textCount.text = $"{_counter}";
            _textEndCount.text = $"{_processor.Completed}";
        }
    }

    protected void TakeResource<Type>(Resource resource)
    {
        for (int i = 0; i < _processor.Completed; i++)
            _resourceCollector.AddResource<Type>(resource);
    }

    private bool ValiadateAdd<T>()
    {
        int countList = _resourceCollector.GetCountList<T>();

        if (_counter <= countList && countList != 0 )
            return true;

        return false;
    }


    protected void Reset()
    {
        if (_processor.Completed > 0)
        {
            _counter = 0;
            _processor.Reset();
            _textCount.text = $"{_counter}";
            _textEndCount.text = $"{_processor.Completed}";
        }
    }

    private void OnDisable() => _processor.Done -= ConversionComplit;
    
}