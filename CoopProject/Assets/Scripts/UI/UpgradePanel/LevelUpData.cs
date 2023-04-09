using UnityEngine;

namespace DefaultNamespace.UI.UpgradePanel
{
    public class LevelUpData : MonoBehaviour
    {
        [SerializeField] private int _instanceHelpers = 0;
        [SerializeField] private int _extractedResources = 0;


        public int InstanceHelpers => _instanceHelpers;
        public int ExtractedResources  => _extractedResources;
        

        public void SetData(out int countInstance,out int extractedResource)
        {
            countInstance = _instanceHelpers;
            extractedResource = _extractedResources;
        }
    }
}