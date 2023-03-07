using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldViue : ShopElementViue
{
    private void Awake()
    {
        _resourceNumber.text = $"{_resourceCount}";
    }
}
