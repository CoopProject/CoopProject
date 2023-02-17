using System;
using System.Collections;
using System.Collections.Generic;
using ResourcesColection;
using ResourcesColection.Tree;
using ResourcesGame;
using TMPro;
using UnityEngine;

public class UIResourceTree : MonoBehaviour
{
    [SerializeField] private ShopResource _shopResource;
    [SerializeField] private TextMeshProUGUI _text;

    private List<Resource> _treeColetion;
    private int _sumResourcePrice;

    public int SumResourcePrice => _sumResourcePrice;

    private void OnEnable()
    {
        _treeColetion = _shopResource.SetListColection<ResourceTree>();
        _text.text = $"{_treeColetion.Count}";
        SumValueResource();
    }
    
    private void SumValueResource()
    {
        if (_treeColetion != null)
        {
            foreach (var resource in _treeColetion)
            {
                _sumResourcePrice += resource.Price;
            }
        }
    }
}
