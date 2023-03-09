using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class WoodViues : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _resourceCount;
  [SerializeField] private Button _buttonSale;
  [SerializeField] private Button _buttonReward;

  public event Action<int> NewValue;

  private void OnEnable()
  {
    NewValue += SetValueCount;
  }

  public int Count { get; private set; } = 0;
  
  private void SetValueCount(int value)
  {
    Count = value;
    _resourceCount.text = $"{Count}";
  }

  public void SetValue(int value)
  {
    NewValue?.Invoke(value);
  }

  private void OnDisable()
  {
    NewValue -= SetValueCount;
  }
}
