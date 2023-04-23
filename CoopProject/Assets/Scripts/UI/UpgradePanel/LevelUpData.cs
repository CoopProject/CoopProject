using System;
using UnityEngine;

namespace DefaultNamespace.UI.UpgradePanel
{
    [Serializable]
    public class LevelUpData
    {
        [SerializeField] private int _instanceHelpers = 0;
        [SerializeField] private int _extractedResources = 0;
        [SerializeField] private int _levelUpPrice = 10;
        [SerializeField] private int _levelUpRewardPrice = 20;

        public int InstanceHelpers => _instanceHelpers;
        public int ExtractedResources  => _extractedResources;
        public int LevelUpPrice => _levelUpPrice;
        public int LevelUpReward => _levelUpRewardPrice;
        

        public void SetData(out int countInstance,out int extractedResource)
        {
            countInstance = _instanceHelpers;
            extractedResource = _extractedResources;
        }
    }
}