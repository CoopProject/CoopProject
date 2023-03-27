using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IronView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourceCount;
    [Header("Кнопка обычной продажи")]
    [SerializeField] private Button _buttonSale;
    [SerializeField] private TextMeshProUGUI _buttonTextSale;
    [Header("Кнопка ревард рекламы")]
    [SerializeField] private Button _buttonReward;
    [SerializeField] private TextMeshProUGUI _buttonTextRewarSale;

    private void OnEnable()
    {
   
    }

    public void SetValueCount(int resourceCount)
    {
        _resourceCount.text = $"{resourceCount}";
    }
  

    public void SetPriceButton(int value)
    {
        _buttonTextSale.text = $"{value}";
        _buttonTextRewarSale.text = $"{value * 2}";

    }

    private void OnDisable()
    {
    
    }
}
