using System;
using UnityEngine;

public class Tarpaulin<T> : MonoBehaviour
{
    [SerializeField] protected string KeyData = "Samwill";
    [SerializeField] protected GameData _data;
    [SerializeField] protected OpenPanel<T> _openPanel;

    protected bool _objectActive ;

    private void Awake()
    {
        _objectActive = _data.LoadObject(KeyData);
        Debug.Log(_objectActive);
    }

    protected void ActiveBuilding()
    {
        if (_objectActive)
            _openPanel.ObjectActive();
        
    }

    public void ActiveObject()
    {
        _objectActive = true;
        _data.SaveObject(KeyData,_objectActive); 
    }

    public void Delete() => gameObject.SetActive(false);
}
