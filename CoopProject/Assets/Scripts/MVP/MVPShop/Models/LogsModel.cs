
using UnityEngine;

public class LogsModel 
{
   public int CountElements { get; private set; } = 0;


   public void SetValueCount(int value)
   {
       CountElements = value;
   }

}
