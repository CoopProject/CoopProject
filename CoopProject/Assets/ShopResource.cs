using System;
using System.Collections;
using System.Collections.Generic;
using ResourcesColection;
using ResourcesGame;
using TMPro;
using UnityEngine;

public class ShopResource : MonoBehaviour
{
   [SerializeField] private ResourceCollector _resourceCollector;
   public List<Resource> SetListColection<ResourceType>() where ResourceType : Resource
   {
      return _resourceCollector.SetColectionResources<ResourceType>();
   }

}
