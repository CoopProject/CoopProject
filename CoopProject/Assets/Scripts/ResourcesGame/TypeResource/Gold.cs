using System;
using Unity.VisualScripting;
using UnityEngine;

namespace ResourcesGame.TypeResource
{
    public  class Gold : Resource
    {
        private int priceLog = 35;
        public void SetPrice() => Price = priceLog;
    }
}