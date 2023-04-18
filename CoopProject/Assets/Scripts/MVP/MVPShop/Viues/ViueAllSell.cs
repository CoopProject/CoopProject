using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViueAllSell : MonoBehaviour
{
   [SerializeField] private List<ViueUI> _viue;
   [SerializeField] private Button _buttonSellAll;
   [SerializeField] private TextMeshProUGUI _textButtonSell;
   [SerializeField] private Button _buttonRewarSellAll;
   [SerializeField] private TextMeshProUGUI _textRewardButtonSell;

   public Button ButtonSellAll => _buttonSellAll;
   public Button ButtonReward => _buttonSellAll;

   private int _sumResource = 0;

   private void OnEnable() => SetValue();

   public void SetValue()
   {
      for (int i = 0; i < _viue.Count; i++)
      {
         _sumResource += _viue[i].Price;
         _textButtonSell.text = $"{_sumResource}";
         _textRewardButtonSell.text = $"{_sumResource * 2}";
      }

      _sumResource = 0;
   }

   public void SellAll() => SetValue();
   
}
