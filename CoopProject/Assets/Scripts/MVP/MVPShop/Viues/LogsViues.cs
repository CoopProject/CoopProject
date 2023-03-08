using System;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogsViues : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _resourceCount;
  [SerializeField] private Button _buttonSale;
  [SerializeField] private Button _buttonReward;
  
  private ResourceCollector _resourceCollector;

  public event Action<int> NewValue;
  public int Count { get; private set; } = 0;
  
  [Inject]
  private void Inject(Container container)
  {
    _resourceCollector = container.Resolve<ResourceCollector>();
  }
  
  public void SetValueCount()
  {
    Count = _resourceCollector.GetCountList<Log>();
    _resourceCount.text = $"{Count}";
  }

  public void SetValue(int value)
  {
    NewValue?.Invoke(value);
  }
}
