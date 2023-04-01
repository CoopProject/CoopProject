using System;
using UnityEngine;

namespace ResourcesGame.TypeResource
{
    public class Log : Resource
    {
        private int priceLog = 15;
        public void SetPrice()=> Price = priceLog;
    }
}