using System;
using System.Collections.Generic;
using ResourcesGame.TypeResource;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private int _priceLog = 10;
    [SerializeField] private int _priceStone = 13;
    [SerializeField] private int _priceIron = 21;
    [SerializeField] private int _priceGold = 20;
    [Space]
    [SerializeField] private int _priceBoards = 15;
    [SerializeField] private int _priceStoneBloks = 25;
    [SerializeField] private int _priceIronIgnots = 30;
    [SerializeField] private int _priceGoldIgnots = 40;

    private float _durationDeleay = 5f;

    public int DataResourceLog { get; private set; }
    public int DataResourceStone { get; private set; }
    public int DataResourceGold { get; private set; }
    public int DataResourceBoards { get; private set; }
    public int DataResourceIron { get; private set; }
    public int DataResourceStoneBlocks { get; private set; }
    public int DataResourceIronIgnots { get; private set; }
    public int DataResourceGoldIgnots { get; private set; }

    private int _counterResourceLog;
    private int _counterResourceStone;
    private int _counterResourceGold;
    private int _counterResourceBoards;
    private int _counterResourceIron;
    private int _counterResourceStoneBlocks;
    private int _counterResourceIronIgnots;
    private int _counterResourceGoldIgnots;

    private Dictionary<Type, int> _resources;
    private Dictionary<Type, int> _priceResource;


    private void Awake()
    {
        LoadData();
        _resources = new Dictionary<Type, int>
        {
            [typeof(Gold)] = _counterResourceGold = DataResourceGold,
            [typeof(Log)] = _counterResourceLog = DataResourceLog,
            [typeof(Stone)] = _counterResourceStone = DataResourceStone,
            [typeof(StoneBlocks)] = _counterResourceStoneBlocks = DataResourceStoneBlocks,
            [typeof(Boards)] = _counterResourceBoards = DataResourceBoards,
            [typeof(Iron)] = _counterResourceIron = DataResourceIron,
            [typeof(IronIngots)] = _counterResourceIronIgnots = DataResourceIronIgnots,
            [typeof(GoldIngots)] = _counterResourceGoldIgnots = DataResourceGoldIgnots
        };

        _priceResource = new Dictionary<Type, int>
        {
            [typeof(Gold)] = _priceGold,
            [typeof(Log)] = _priceLog,
            [typeof(Stone)] = _priceStone,
            [typeof(StoneBlocks)] = _priceStoneBloks,
            [typeof(Boards)] = _priceBoards,
            [typeof(Iron)] = _priceIron,
            [typeof(IronIngots)] = _priceIronIgnots,
            [typeof(GoldIngots)] = _priceGoldIgnots
        };
    }

    public void AddResource<TypeResource>()
    {
        _resources[typeof(TypeResource)]++;
        SaveData();
    }


    public int GetCountList<TypeResource>()
    {
        var count = _resources[typeof(TypeResource)];
        return count;
    }

    public int GetResourcePrice<TypeResource>()
    {
        if (_resources[typeof(TypeResource)] > 0)
            return _priceResource[typeof(TypeResource)];

        return 0;
    }

    public void SellResource<TypeResource>()
    {
        _resources[typeof(TypeResource)] = 0;
    }


    public void SellCountResource<TypeResource>(int countResource)
    {
        if (countResource == _resources[typeof(TypeResource)])
            _resources[typeof(TypeResource)] = 0;

        else if (_resources[typeof(TypeResource)] > countResource)
            _resources[typeof(TypeResource)] -= countResource;
        
    }

    private void SaveData()
    {
        DataResourceLog = _resources[typeof(Log)];
        DataResourceStone = _resources[typeof(Stone)];
        DataResourceGold = _resources[typeof(Gold)];
        DataResourceBoards = _resources[typeof(Boards)];
        DataResourceIron = _resources[typeof(Iron)];
        DataResourceStoneBlocks = _resources[typeof(StoneBlocks)];
        DataResourceIronIgnots = _resources[typeof(IronIngots)];
        DataResourceGoldIgnots = _resources[typeof(GoldIngots)];

        PlayerPrefs.SetInt("Log", DataResourceLog);
        PlayerPrefs.SetInt("Stone", DataResourceStone);
        PlayerPrefs.SetInt("Gold", DataResourceGold);
        PlayerPrefs.SetInt("Boards", DataResourceBoards);
        PlayerPrefs.SetInt("Iron", DataResourceIron);
        PlayerPrefs.SetInt("StoneBlocks", DataResourceStoneBlocks);
        PlayerPrefs.SetInt("IronIgnots", DataResourceIronIgnots);
        PlayerPrefs.SetInt("GoldIgnots", DataResourceGoldIgnots);
    }

    private void LoadData()
    {
        DataResourceLog =  PlayerPrefs.GetInt("Log");
        DataResourceStone = PlayerPrefs.GetInt("Stone");
        DataResourceGold = PlayerPrefs.GetInt("Gold");
        DataResourceBoards = PlayerPrefs.GetInt("Boards");
        DataResourceIron = PlayerPrefs.GetInt("Iron");
        DataResourceStoneBlocks = PlayerPrefs.GetInt("StoneBlocks");
        DataResourceIronIgnots = PlayerPrefs.GetInt("IronIgnots");
        DataResourceGoldIgnots = PlayerPrefs.GetInt("GoldIgnots");
    }
}