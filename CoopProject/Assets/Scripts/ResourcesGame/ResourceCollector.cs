using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourcesGame.TypeResource;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private int _priceLog = 10;
    [SerializeField] private int _priceStone = 13;
    [SerializeField] private int _priceGold = 20;
    [SerializeField] private int _priceBoards = 15;
    [SerializeField] private int _priceIron = 21;
    [SerializeField] private int _priceStoneBloks = 25;
    [SerializeField] private int _priceIronIgnots = 30;
    [SerializeField] private int _priceGoldIgnots = 40;
    
     [ES3Serializable] private int _dataResourceLog;
     [ES3Serializable] private int _dataResourceStone;
     [ES3Serializable] private int _dataResourceGold;
     [ES3Serializable] private int _dataResourceBoards;
     [ES3Serializable] private int _dataResourceIron;
     [ES3Serializable] private int _dataResourceStoneBlocks;
     [ES3Serializable] private int _dataResourceIronIgnots;
     [ES3Serializable] private int _dataResourceGoldIgnots;
    
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
       _resources = new Dictionary<Type, int>
       {
           [typeof (Gold)] = _counterResourceGold = _dataResourceGold,
           [typeof (Log)] = _counterResourceLog = _dataResourceLog,
           [typeof (Stone)] = _counterResourceStone = _dataResourceStone,
           [typeof (StoneBlocks)] = _counterResourceStoneBlocks = _dataResourceStoneBlocks,
           [typeof (Boards)] = _counterResourceBoards = _dataResourceBoards,
           [typeof (Iron)] = _counterResourceIron = _dataResourceIron,
           [typeof (IronIngots)] = _counterResourceIronIgnots = _dataResourceIronIgnots,
           [typeof (GoldIngots)] = _counterResourceGoldIgnots = _dataResourceGoldIgnots
       };
        
       _priceResource = new Dictionary<Type, int>
       {
           [typeof (Gold)] = _priceGold,
           [typeof (Log)] = _priceLog,
           [typeof (Stone)] = _priceStone,
           [typeof (StoneBlocks)] = _priceStoneBloks,
           [typeof (Boards)] = _priceBoards,
           [typeof (Iron)] = _priceIron,
           [typeof (IronIngots)] = _priceIronIgnots,
           [typeof (GoldIngots)] = _priceGoldIgnots
       };
   }

   public void AddResource<TypeResource>()
    {
        _resources[typeof(TypeResource)]++;
        SaveData();
    }

    private void SaveData()
    {
        _dataResourceLog = _resources[typeof(Log)];
        _dataResourceStone = _resources[typeof(Stone)];
        _dataResourceGold = _resources[typeof(Gold)];
        _dataResourceBoards = _resources[typeof(Boards)];
        _dataResourceIron = _resources[typeof(Iron)];
        _dataResourceStoneBlocks = _resources[typeof(StoneBlocks)];
        _dataResourceIronIgnots = _resources[typeof(IronIngots)];
        _dataResourceGoldIgnots = _resources[typeof(GoldIngots)];
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
        SaveData();
    }


    public void SellCountResource<TypeResource>(int countResource)
    {
        if (countResource == _resources[typeof(TypeResource)])
            _resources[typeof(TypeResource)] = 0;

        else if (_resources[typeof(TypeResource)] > countResource)
            _resources[typeof(TypeResource)] -= countResource;
        SaveData();
    }
}