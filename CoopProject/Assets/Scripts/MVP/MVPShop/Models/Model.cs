public class Model 
{
   public int CountElements { get; private set; } = 0;

   public void SetValueCount<T>(ResourceCollector resourceCollector)
   {
       CountElements = resourceCollector.GetCountList<T>();
   }

}
