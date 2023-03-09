using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.MVC.MVPShop.Prisenters;
using UnityEngine;
using UnityEngine.Serialization;

public class SetupShop : MonoBehaviour
{
    [SerializeField] private WoodViues woodViues;
    [SerializeField] private GoldViue _goldViue;
    [SerializeField] private StoneViue _stoneViue;
    [SerializeField] private IronViue _ironViue;
    
    private WoodPresenter _presenterWood;
    private GoldPresenter _presenterGold;
    private StonePrisenter _prisenterStone;
    private IronPresenter _presenterIron;
    
    private WoodModel _woodModel = new ();
    private GoldModel _goldModel = new ();
    private StoneModel _stoneModel = new ();
    private IronModel _ironModel = new ();
    


    private void Awake()
    {
        _presenterWood = new WoodPresenter(_woodModel, woodViues);
        _presenterGold = new GoldPresenter(_goldModel,_goldViue);
        _prisenterStone = new StonePrisenter(_stoneModel,_stoneViue);
        _presenterIron = new IronPresenter(_ironModel,_ironViue);

    }

    private void Start()
    {
        _presenterWood.Start();
        _presenterGold.Start();
        _prisenterStone.Start();
        _presenterIron.Start();
    }
}
