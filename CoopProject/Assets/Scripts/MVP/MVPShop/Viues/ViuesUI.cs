using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class ViuesUI : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _resourceCount;
  [SerializeField] private Button _buttonSale;
  [SerializeField] private Button _buttonReward;

  private event Action OnActive;


  private void SetCountResource(int count)
  {
    _resourceCount.text =$"{count}";
  }
  
}
