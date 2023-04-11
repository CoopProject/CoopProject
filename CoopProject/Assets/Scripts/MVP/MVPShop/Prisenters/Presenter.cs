
namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class Presenter<T>
    {
        private Model _model;
        private ViueUI _viueUI;
        private ResourceCollector _resourceCollector;
        private PlayerWallet _playerWallet;
        private ViueAllSell _viueAllSell;
        
        public Presenter(Model model,ViueUI viuesUI,ResourceCollector resourceCollector,PlayerWallet playerWallet,ViueAllSell viueAllSell)
        {
            _model = model;
            _viueUI = viuesUI;
            _resourceCollector = resourceCollector;
            _playerWallet = playerWallet;
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
            _model.SetCoinPlayer(_playerWallet);
            _model.ClearData<T>(_resourceCollector);
            _model.SetValueCount<T>(_resourceCollector);
            _viueUI.SetCountResource(_model.CountElements);
            _viueUI.SetPriceButton(_model.SumResource);
        }
    }
}