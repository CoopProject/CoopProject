using ResourcesGame.TypeResource;
using TMPro;
using UnityEngine;

public abstract class ProductPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private TextMeshProUGUI _textEndCount;
    [SerializeField] private int _stack = 10;

    protected ResourceCollector _resourceCollector;
    private int _counter = 0;
    private int _addResourceCount = 0;

    private void Start()
    {
        _textCount.text = $"{_counter}";
        _textEndCount.text = $"{_addResourceCount}";
    }

    protected void SetCount<T>()
    {
        if (ValiadateAdd<T>())
        {
            _counter++;
            _addResourceCount = _counter;
            _textCount.text = $"{_counter}";
            _textEndCount.text = $"{_addResourceCount}";
        }
    }

    protected void SetStackCount<T>()
    {
        int countList = _resourceCollector.GetCountList<T>();

        if (countList > _stack && _counter + _stack <= countList)
        {
            _counter += _stack;
            _addResourceCount = _counter;
            _textCount.text = $"{_counter}";
            _textEndCount.text = $"{_addResourceCount}";
        }
    }

    protected void Take()
    {
        if (_counter + _stack <= 0)
        {
            _counter -= _stack;
            _textCount.text = $"{_counter}";
            _addResourceCount = _counter;
            _textEndCount.text = $"{_addResourceCount}";
        }
    }

    protected void TakeResource<Type>(Resource resource)
    {
        for (int i = 0; i < _addResourceCount; i++)
            _resourceCollector.AddResource<Type>(resource);
        
    }

    private bool ValiadateAdd<T>()
    {
        int countList = _resourceCollector.GetCountList<T>();

        if (_counter < countList)
            return true;

        return false;
    }


   protected void Reset<Type>()
    {
        if (_counter > 0 && _addResourceCount > 0)
        {
            _counter = 0;
            _addResourceCount = 0;
            _textCount.text = $"{_counter}";
            _textEndCount.text = $"{_addResourceCount}";
            _resourceCollector.SallResource<Type>();
        }
    }
}