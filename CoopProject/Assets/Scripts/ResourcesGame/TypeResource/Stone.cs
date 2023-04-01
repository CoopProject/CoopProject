using UnityEngine;

namespace ResourcesGame.TypeResource
{
    public class Stone : Resource
    {
        private int priceLog = 25;
        public void SetPrice()=> Price = priceLog;
    }
}