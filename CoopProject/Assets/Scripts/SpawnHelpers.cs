using UnityEngine;

public class SpawnHelpers : MonoBehaviour
{
   [SerializeField] private Helper _helperObject;

   private FactoryHelpers _factoryHelpers;

   private void OnEnable()
   {
       _factoryHelpers = new FactoryHelpers();
   }
   
   private void Start()
   {
     var helper =  _factoryHelpers.InstanceHelper(_helperObject,transform);
   }
}
