
namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class Presenter<T>
    {
        private Model _model;
        private ViueUI _viueUI;
        private ResourceCollector _resourceCollector;
        private Player _player;
        private ViueAllSell _viueAllSell;
        
        public Presenter(Model model,ViueUI viuesUI,ResourceCollector resourceCollector,Player player,ViueAllSell viueAllSell)
        {
            _model = model;
            _viueUI = viuesUI;
            _resourceCollector = resourceCollector;
            _player = player;
            _viueAllSell = viueAllSell;

            _viueUI.OnActive += SetStartData;
            _viueUI._buttonSale.onClick.AddListener(ClickButtonViue);
            
            _viueAllSell.ButtonSellAll.onClick.AddListener(ClickButtonViue);
        }
        
        private void SetStartData()
        {
            _model.SetValueCount<T>(_resourceCollector);
            _viueUI.SetCountResource(_model.CountElements);
            _viueUI.SetPriceButton(_model.SumResource);
        }

        private void ClickButtonViue()
        {
            _model.SetCoinPlayer(_player);
            _model.ClearData<T>(_resourceCollector);
            _model.SetValueCount<T>(_resourceCollector);
            _viueUI.SetCountResource(_model.CountElements);
            _viueUI.SetPriceButton(_model.SumResource);
        }
    }
}