using UnityEngine;

namespace ResourcesGame.TypeResource
{
    public class Iron :Resource
    {
        private int priceLog = 45;
        public void SetPrice()=> Price = priceLog;
    }
}