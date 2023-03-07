using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IronViue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourceCount;
    [SerializeField] private Button _buttonSale;
    [SerializeField] private Button _buttonReward;

    public int Count { get; private set; } = 0;
    
    public void SetValueCount(int value)
    {
        Count = value;
        _resourceCount.text = $"{Count}";
    }
}
