using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private Dictionary<string, int> _dataGame = new ();
    private Dictionary<string, bool> _dataObject = new();
    private string _data = "";
    private string _dataObjectActive = "";
    
    private void Awake()
    {
        LoadDataObject();
        
// #if YANDEX_GAMES && UNITY_WEBGL && !UNITY_EDITOR
//         LoadData();
//         LoadDataObject();
// #endif
    }

    public void SaveObject(string key,bool value)
    {
        if (key != "")
        {
            if (_dataObject.ContainsKey(key))
            {
                _dataObject[key] = value;
                SaveDataObject();
            }
            else
            {
                _dataObject.Add(key, value);
                SaveDataObject();
            }
        }
    }


    
    private void SaveDataObject()
    {
        _dataObjectActive = JsonUtility.ToJson(_dataObject);
        PlayerPrefs.SetString("dataObjectActive",_dataObjectActive);
    }

    private void LoadDataObject()
    {
        _dataObjectActive = PlayerPrefs.GetString("dataObjectActive","");
        Debug.Log(_dataObjectActive);
        
        if (_dataObjectActive != "")
        {
            Dictionary<string,bool> data =  JsonConvert.DeserializeObject<Dictionary<string, bool>>(_dataObjectActive);
            _dataObject = data;
        }
    }

    public int Load(string key)
    {
        foreach (var wood in _dataGame )
        {
            if (_dataGame.ContainsKey(key))
            {
               return PlayerPrefs.GetInt(key,0);
            }
        }
        return 0;
    }
    
    public bool LoadObject(string key)
    {
        foreach (var wood in _dataObject)
        {
            if (_dataObject.ContainsKey(key))
            {
                return true;
            }
        }
        return false;
    }
}
