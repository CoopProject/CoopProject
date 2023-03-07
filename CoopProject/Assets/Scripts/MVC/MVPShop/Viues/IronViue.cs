using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IronViue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourceCount;

    public int Count { get; private set; } = 0;
    
    public void SetValueCount(int value)
    {
        Count = value;
        _resourceCount.text = $"{Count}";
    }
}
