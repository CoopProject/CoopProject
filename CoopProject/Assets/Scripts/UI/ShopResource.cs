using ResourcesColection.Tree;
using TMPro;
using UnityEngine;

public class ShopResource : MonoBehaviour
{
   [SerializeField] private ResourceCollector _resourceCollector;
   [SerializeField] private TextMeshProUGUI _sumPriceResource;

   private int SumAllResource;

   private void OnEnable()
   {
      _sumPriceResource.text +=
         $" {_resourceCollector.SumPriceAllResource<ResourceTree>() + _resourceCollector.SumPriceAllResource<ResourceRock>()}";
   }
}
