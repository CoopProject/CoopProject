using ResourcesColection;

namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class Presenter<T>
    {
        private Model _model;
        private ViuesUI _viueUI;
        private ResourceCollector _resourceCollector;
        
        public Presenter(Model model,ViuesUI viuesUI,ResourceCollector resourceCollector)
        {
            _model = model;
            _viueUI = viuesUI;
            _resourceCollector = resourceCollector;

            _viueUI.OnActive += () =>
            {
                _model.SetValueCount<T>(_resourceCollector);
                _viueUI.SetCountResource(_model.CountElements);
            };
        }
    }
}