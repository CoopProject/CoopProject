using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViueUI : MonoBehaviour
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
  public event Action ButtonClick;
  public int Count { get; private set; } = 0;
  public int Price { get; private set; } = 0;

  public void SetTartData() => OnActive?.Invoke();

  public void SetCountResource(int count)
  {
    Count = count;
    _resourceCount.text = $"{count}";
  }

  public void SetPriceButton(int value)
  {
    _textButtonPrice.text = $"{value}";
    _textRewardButtonPrice.text = $"{value * 2}";
    Price = value;
  }

  public void SellButtonClick() => ButtonClick?.Invoke();
}
