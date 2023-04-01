using DefaultNamespace.MVP.MVPShop.Viues;

namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class PresenterStats<T>
    {
        private Model _model;
        private StatsView _viueUI;
        private ResourceCollector _resourceCollector;
        
        public PresenterStats(Model model,StatsView viuesUI,ResourceCollector resourceCollector)
        {
            _model = model;
            _viueUI = viuesUI;
            _resourceCollector = resourceCollector;

            _viueUI.OnUpdate += () =>
            {
                _model.SetValueCount<T>(_resourceCollector);
                _viueUI.SetValue(_model.CountElements);
            };
        }
    }
}