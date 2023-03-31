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
  [SerializeField] private TextMeshProUGUI _textButtonPrice;
  [Space]
  [Header("Кнопка рекламы")]
  [SerializeField] private Button _buttonReward;
  [SerializeField] private TextMeshProUGUI _textRewardButtonPrice;
  public event Action OnActive;

  public int Count { get; private set; } = 0;

  private void OnEnable()
  {
    OnActive?.Invoke();
  }

  private void Start()
  {
   // ValidateData();
  }

  private void ValidateData()
  {
    if (Count <= 0)
      gameObject.SetActive(false);
    else
      gameObject.SetActive(true);
  }

  public void SetCountResource(int count)
  {
    Count = count;
    _resourceCount.text = $"{count}";
  }

  public void SetPriceButton(int value)
  {
    _textButtonPrice.text = $"{value}";
    _textRewardButtonPrice.text = $"{value * 2}";
  }
  
}
