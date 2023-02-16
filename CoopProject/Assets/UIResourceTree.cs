using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIResourceTree : MonoBehaviour
{
    [SerializeField] private ShopResource _shopResource;
    [SerializeField] private TextMeshProUGUI _text;

    private List<IResource> _treeColetion;

    private void Start()
    {
        _treeColetion = _shopResource.SetListColection<ResourceTree>();
        _text.text = $"{_treeColetion.Count}";
    }
}
