using System.Collections.Generic;
using UnityEngine;

public class SwitchUIPanel : MonoBehaviour
{
   [SerializeField] private List<ViueUI> _viues;
   [SerializeField] private ViueAllSell _viueAllSell;

   private void FixedUpdate()
   {
      SetAllStartData();
      _viueAllSell.SetValue();
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
