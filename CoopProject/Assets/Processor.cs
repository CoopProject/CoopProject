using System;
using System.Collections;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private ProductPanel _panel;
    [SerializeField] private float _duration = 1f;

    private int _�ountTransformation = 1;
    private int _�ompleted = 0;
    private bool _iWorik = false;
    public event Action Done; 

    public int CountTransformation => _�ountTransformation;
    public int Completed => _�ompleted;


    private void Update()
    {
        if (_iWorik)
        {
            StartCoroutine(Transformation());
            _iWorik = false;
        }
    }

    public void Conversion(int count)
    {
        _�ountTransformation = count;
        _iWorik = true;
    }

    private IEnumerator Transformation()
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(_duration);
        while (_�ountTransformation >= _�ompleted)
        {
            yield return waitForSecondsRealtime;
            _�ountTransformation--;
            _�ompleted++;
            _panel.ConversionComplit();
            Done?.Invoke();
        }
    }

    public void Reset()
    {
        _�ountTransformation = 0;
        _�ompleted = 0;
    }
}
