using System;
using UnityEngine;

public class Tarpaulin<T> : MonoBehaviour
{
    [SerializeField] protected string KeyData = "Samwill";
    [SerializeField] protected OpenPanel<T> _openPanel;

    protected int _objectActive ;

    private void Awake()
    {
        _objectActive = PlayerPrefs.GetInt(KeyData,_objectActive);
    }

    protected void ActiveBuilding()
    {
        if (_objectActive == 1)
            _openPanel.ObjectActive();
        
    }

    public void ActiveObject()
    {
        _objectActive = 1;
        PlayerPrefs.SetInt(KeyData,_objectActive); 
    }

    public void Delete() => gameObject.SetActive(false);
}
