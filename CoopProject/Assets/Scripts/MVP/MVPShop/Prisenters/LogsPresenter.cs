
namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class LogsPresenter
    {
        private LogsModel _model;
        private LogsView _view;
        private ResourceCollector _resourceCollector;

        public LogsPresenter(LogsModel model, LogsView view,ResourceCollector ResourceCollector)
        {
            _model = model;
            _view = view;
            _resourceCollector = ResourceCollector;
            
            _model.OnSetCount += _view.SetValueCount;
            _model.ReadySumResource += _view.SetPriceButton;
            
            _model.SetStartData(_resourceCollector);
        }
    }
}