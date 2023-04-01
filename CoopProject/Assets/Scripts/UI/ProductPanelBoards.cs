using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;


public class ProductPanelBoards : ProductPanel
{
   
   [Inject]
   private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
   
   public void AddResource()
   {
      SetCount<Log>();
   }

   public void AddStack()
   {
      SetStackCount<Log>();
   }

   public void TakeStack()
   {
      Take();
   }

   public void TakeConvertType()
   {
      Boards board = new();
      board.SetPrice();
      TakeResource<Log>(board);
   }
}
