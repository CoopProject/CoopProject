using System;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUIPanel : MonoBehaviour
{
   [SerializeField] private List<ViewUI> _viues;
   [SerializeField] private ViewAllSell viewAllSell;
   

   private void FixedUpdate()
   {
      SetAllStartData();
      viewAllSell.SetValue();
   }

   private void SetAllStartData()
   {
      for (int i = 0; i < _viues.Count; i++)
      {
         _viues[i].SetTartData();
         if (_viues[i].Count > 0)
         {
            _viues[i].gameObject.SetActive(true);
         }
         else
         {
            _viues[i].gameObject.SetActive(false);
         }
      }
   }
}