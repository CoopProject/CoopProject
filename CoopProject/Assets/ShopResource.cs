using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopResource : MonoBehaviour
{
   [SerializeField] private ResourceCollector _resourceCollector;
   
   public List<IResource> SetListColection<ResourceType>() where ResourceType : IResource
   {
      return _resourceCollector.SetColectionResources<ResourceType>();
   }

}
