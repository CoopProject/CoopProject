using UnityEngine;

namespace ResourcesGame.TypeResource
{
    public class IronIngots : Resource
    {
        private int priceLog = 65;
        public void SetPrice()=> Price = priceLog;
    }
}