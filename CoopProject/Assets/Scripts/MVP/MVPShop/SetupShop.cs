using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.MVC.MVPShop.Prisenters;
using UnityEngine;
using UnityEngine.Serialization;

public class SetupShop : MonoBehaviour
{
    [SerializeField] private WoodViues woodViues;
    [SerializeField] private GoldView _goldView;
    [SerializeField] private StoneView _stoneView;
    [SerializeField] private IronView _ironView;
    
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
        /*_presenterGold = new GoldPresenter(_goldModel,_goldView);
        _prisenterStone = new StonePrisenter(_stoneModel,_stoneView);
        _presenterIron = new IronPresenter(_ironModel,_ironView);*/
    }

    private void Start()
    {
        _presenterWood.Start();
        /*_presenterGold.Start();
        _prisenterStone.Start();
        _presenterIron.Start();*/
    }
}
