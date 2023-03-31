using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class ViuesUI : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _resourceCount;
  [Space]
  [Header("Обычная кнопка продажи")]
  [SerializeField] private Button _buttonSale;
  [SerializeField] private Text _textButtonPrice;
  [Space]
  [Header("Кнопка рекламы")]
  [SerializeField] private Button _buttonReward;
  [SerializeField] private Text _textRewardButtonPrice;
  public event Action OnActive;

  private void OnEnable()
  {
    OnActive?.Invoke();
  }

  public void SetCountResource(int count)
  {
    _resourceCount.text =$"{count}";
  }
  
}
