using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ShopElementViue : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _resourceNumber;

    protected int _resourceCount = 0;
}
