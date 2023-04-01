public class Model
{
    public int CountElements { get; private set; } = 0;
   public int PriceResource { get; private set; } = 0;

   public int SumResource = 0;
   

   public void SetValueCount<T>(ResourceCollector resourceCollector)
   {
       CountElements = resourceCollector.GetCountList<T>();
       PriceResource = resourceCollector.GetResourcePrice<T>();
       SumResourcePrice();
   }

   private void SumResourcePrice()
   {
       SumResource = 0;
       
       for (int i = 0; i < CountElements; i++)
       {
           SumResource += PriceResource;
       }
   }

   public void SetCoinPlayer(Player player)
   {
       player.SetCoinsValue(SumResource);
   }

   public void ClearData<T>(ResourceCollector resourceCollector)
   {
       resourceCollector.SallResource<T>();
   }
}
