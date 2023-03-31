using System;
using TMPro;
using UnityEngine;
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
  public event Action OnStart;
  public event Action ButtonClick;
  public int Count { get; private set; } = 0;

  private void OnEnable()
  {
    SetCountResource(0);
    SetPriceButton(0);
    OnActive?.Invoke();
    OnStart += ActiveComponent;
  }

  private void Start()
  {
    OnStart?.Invoke();
  }

  public void ActiveComponent()
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

  public void SellButtonClick() => ButtonClick?.Invoke();

  private void OnDisable()
  {
    OnActive -= ActiveComponent;
    OnStart -= ActiveComponent;
  }
}
