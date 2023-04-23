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
    [SerializeField] private GameData _data;

    public int DataResourceLog { get; private set;}
     public int DataResourceStone { get; private set;}
     public int DataResourceGold { get; private set;}
     public int DataResourceBoards { get; private set;}
     public int DataResourceIron { get; private set;}
     public int DataResourceStoneBlocks { get; private set;}
     public int DataResourceIronIgnots { get; private set;}
     public int DataResourceGoldIgnots { get; private set;}
    
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
           [typeof (Gold)] = _counterResourceGold = DataResourceGold,
           [typeof (Log)] = _counterResourceLog = DataResourceLog,
           [typeof (Stone)] = _counterResourceStone = DataResourceStone,
           [typeof (StoneBlocks)] = _counterResourceStoneBlocks = DataResourceStoneBlocks,
           [typeof (Boards)] = _counterResourceBoards = DataResourceBoards,
           [typeof (Iron)] = _counterResourceIron = DataResourceIron,
           [typeof (IronIngots)] = _counterResourceIronIgnots = DataResourceIronIgnots,
           [typeof (GoldIngots)] = _counterResourceGoldIgnots = DataResourceGoldIgnots
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
        DataResourceLog = _resources[typeof(Log)];
        DataResourceStone = _resources[typeof(Stone)];
        DataResourceGold = _resources[typeof(Gold)];
        DataResourceBoards = _resources[typeof(Boards)];
        DataResourceIron = _resources[typeof(Iron)];
        DataResourceStoneBlocks = _resources[typeof(StoneBlocks)];
        DataResourceIronIgnots = _resources[typeof(IronIngots)];
        DataResourceGoldIgnots = _resources[typeof(GoldIngots)];
        
        _data.Save("Log",DataResourceLog);
        _data.Save("Stone",DataResourceStone);
        _data.Save("Gold",DataResourceGold);
        _data.Save("Boards",DataResourceBoards);
        _data.Save("Iron",DataResourceIron);
        _data.Save("StoneBlocks",DataResourceStoneBlocks);
        _data.Save("IronIgnots",DataResourceIronIgnots);
        _data.Save("GoldIgnots",DataResourceGoldIgnots);
    }

    private void LoadData()
    {
        DataResourceLog = _data.Load("Log");
        DataResourceStone =_data.Load("Stone");
        DataResourceGold = _data.Load("Gold");
        DataResourceBoards = _data.Load("Boards");
        DataResourceIron = _data.Load("Iron");
        DataResourceStoneBlocks = _data.Load("StoneBlocks");
        DataResourceIronIgnots = _data.Load("IronIgnots");
        DataResourceGoldIgnots = _data.Load("GoldIgnots");
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