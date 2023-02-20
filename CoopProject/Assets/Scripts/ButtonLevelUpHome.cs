using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevelUpHome : MonoBehaviour
{
   [SerializeField] private List<Island> _islands;


   private void OnEnable()
   {
      DisbaleAllIsland();
   }
   
   private void LevelUp(int level)
   {
      if (level <= _islands.Count)
      {
         _islands[level].ActiveIsland();
      }
   }

   private void DisbaleAllIsland()
   {
      foreach (var island in _islands)
      {
         island.DisableIsland();
      }
   }
   
   
   
}
