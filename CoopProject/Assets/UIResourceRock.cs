using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIResourceRock : MonoBehaviour
{
    [SerializeField] private ShopResource _shopResource;
    [SerializeField] private TextMeshProUGUI _text;

    private List<IResource> _treeColetion;

    private void OnEnable()
    {
        _treeColetion = _shopResource.SetListColection<ResourceRock>();
        _text.text = $"{_treeColetion.Count}";
    }
    
}
