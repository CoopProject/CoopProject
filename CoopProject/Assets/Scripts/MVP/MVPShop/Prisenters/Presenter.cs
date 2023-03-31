
namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class Presenter<T>
    {
        private Model _model;
        private ViuesUI _viueUI;
        private ResourceCollector _resourceCollector;
        private Player _player;
        
        public Presenter(Model model,ViuesUI viuesUI,ResourceCollector resourceCollector,Player player)
        {
            _model = model;
            _viueUI = viuesUI;
            _resourceCollector = resourceCollector;
            _player = player;

            _viueUI.OnActive += SetStartData;
            _viueUI.ButtonClick += ClickButtonViue;
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