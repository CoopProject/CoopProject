namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class LogsPresenter
    {
        private LogsModel _model;
        private LogsViues _viue;
        
        public LogsPresenter(LogsModel model,LogsViues viues)
        {
            _model = model;
            _viue = viues;

            _viue.NewValue += _model.SetValueCount;
        }

        public void Start()
        {
            _viue.SetValue(0);
        }

    }
}