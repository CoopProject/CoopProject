using System;
using System.Collections;
using UnityEngine;

public class Processor : MonoBehaviour
{
    [SerializeField] private ProductPanel _panel;
    [SerializeField] private float _duration = 1f;

    private int _ñountTransformation = 1;
    private int _ñompleted = 0;
    private bool _iWorik = false;
    public event Action Done; 

    public int CountTransformation => _ñountTransformation;
    public int Completed => _ñompleted;


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
        _ñountTransformation = count;
        _iWorik = true;
    }

    private IEnumerator Transformation()
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(_duration);
        while (_ñountTransformation >= _ñompleted)
        {
            yield return waitForSecondsRealtime;
            _ñountTransformation--;
            _ñompleted++;
            _panel.ConversionComplit();
            Done?.Invoke();
        }
    }

    public void Reset()
    {
        _ñountTransformation = 0;
        _ñompleted = 0;
    }
}
