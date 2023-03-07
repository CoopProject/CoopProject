using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.MVC.MVPShop.Prisenters;
using UnityEngine;
using UnityEngine.Serialization;

public class SetupShop : MonoBehaviour
{
    [SerializeField] private LogsViues logsViues;
    [SerializeField] private GoldViue _goldViue;
    [SerializeField] private StoneViue _stoneViue;
    [SerializeField] private IronViue _ironViue;
    
    private LogsPresenter _presenterLogs;
    private GoldPresenter _presenterGold;
    private StonePrisenter _prisenterStone;
    private IronPresenter _presenterIron;
    
    private LogsModel _logsModel = new LogsModel();
    private GoldModel _goldModel = new GoldModel();
    private StoneModel _stoneModel = new StoneModel();
    private IronModel _ironModel = new IronModel();
    


    private void Awake()
    {
        _presenterLogs = new LogsPresenter(_logsModel, logsViues);
        _presenterGold = new GoldPresenter(_goldModel,_goldViue);
        _prisenterStone = new StonePrisenter(_stoneModel,_stoneViue);
        _presenterIron = new IronPresenter(_ironModel,_ironViue);

    }

    private void Start()
    {
        _presenterLogs.Start();
        _presenterGold.Start();
        _prisenterStone.Start();
        _presenterIron.Start();
    }
}
