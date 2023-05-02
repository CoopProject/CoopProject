using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewAllSell : MonoBehaviour
{
   [SerializeField] private List<ViewUI> _viue;
   [SerializeField] private Button _buttonSellAll;
   [SerializeField] private TextMeshProUGUI _textButtonSell;
   [SerializeField] private Button _buttonRewarSellAll;
   [SerializeField] private TextMeshProUGUI _textRewardButtonSell;
   
   public Button ButtonSellAll => _buttonSellAll;
   public Button ButtonReward => _buttonRewarSellAll;

   public int PriceAllResources { get; private set; } = 0;
   public int ResourceSum { get; private set; } = 0;

   private void OnEnable() => SetValue();

   public void SetValue()
   {
      for (int i = 0; i < _viue.Count; i++)
      {
         PriceAllResources += _viue[i].Price;
         ResourceSum += _viue[i].Price;
         _textButtonSell.text = $"{PriceAllResources}";
         _textRewardButtonSell.text = $"{PriceAllResources * 2}";
         
      }

      PriceAllResources = 0;
   }


   public void Clear() => ResourceSum = 0;
}
