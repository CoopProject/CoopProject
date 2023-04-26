#pragma warning disable

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
#if YANDEX_GAMES && UNITY_WEBGL && !UNITY_EDITOR
        LoadData();
        LoadDataObject();
#endif
    }
    
    public void Save(string key,int value)
    {
        if (key != "")
        {
            if (_dataGame.ContainsKey(key))
            {
                _dataGame[key] = value;
                PlayerPrefs.SetInt(key,_dataGame[key]);
                SaveData();
            }
            else
            {
                _dataGame.Add(key, value);
                PlayerPrefs.SetInt(key,_dataGame[key]);   
                SaveData();
            }
        }
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

    private void SaveData()
    {
       _data = JsonConvert.SerializeObject(_dataGame, Formatting.Indented);
       PlayerPrefs.SetString("Data",_data);
    }

    private void LoadData()
    {
        _data = PlayerPrefs.GetString("Data","");
        if (_data != "")
        {
             Dictionary<string,int> data =  JsonConvert.DeserializeObject<Dictionary<string, int>>(_data);
             _dataGame = data;
        }
    }
    
    private void SaveDataObject()
    {
        _dataObjectActive = JsonConvert.SerializeObject(_dataObject, Formatting.Indented);
        PlayerPrefs.SetString("dataObjectActive",_dataObjectActive);
    }

    private void LoadDataObject()
    {
        _dataObjectActive = PlayerPrefs.GetString("dataObjectActive","");
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
