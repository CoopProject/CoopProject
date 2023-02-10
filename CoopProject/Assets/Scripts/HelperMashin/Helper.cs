using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Helper : MonoBehaviour, IHelper
{
   [SerializeField] private FindingState _findingState;

   private void Start()
   {
       FindingResources();
   }

   public void FindingResources()
    {
      _findingState.Enter();  
    }
}