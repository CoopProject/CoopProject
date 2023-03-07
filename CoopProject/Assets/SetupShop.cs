using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.MVC.MVPShop.Prisenters;
using UnityEngine;

public class SetupShop : MonoBehaviour
{
    [SerializeField] private WodoViues _wodoViues;
    [SerializeField] private GoldViue _goldViue;
    [SerializeField] private StoneViue _stoneViue;
    [SerializeField] private IronViue _ironViue;
    
    
    private WodoPrisenter _prisenter;
    private WodoModel _wodoModel = new WodoModel();


    private void Awake()
    {
        _prisenter = new WodoPrisenter(_wodoModel, _wodoViues);
    }

    private void Start()
    {
        _prisenter.Start();
    }
}
