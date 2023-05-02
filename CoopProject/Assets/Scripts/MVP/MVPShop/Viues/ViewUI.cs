using System;
using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewUI : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _resourceCount;
  [Space]
  [Header("Обычная кнопка продажи")]
  [SerializeField] public Button _buttonSale;
  [SerializeField] private TextMeshProUGUI _textButtonPrice;
  [Space]
  [Header("Кнопка рекламы")]
  [SerializeField] public Button _buttonReward;
  [SerializeField] private TextMeshProUGUI _textRewardButtonPrice;
  
  public event Action OnActive;
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

  public void SellButtonRewardClick() => _buttonReward.onClick.Invoke();
  

  public void SellButtonClick() => _buttonSale.onClick.Invoke();
}
