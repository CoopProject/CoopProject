namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class LogsPresenter
    {
        private LogsModel _model;
        private LogsViues _viue;

        public LogsPresenter(LogsModel model, LogsViues viues)
        {
            _model = model;
            _viue = viues;
        }

        public void Start()
        {
            _viue.SetValueCount();
            _model.SetValueCount(_viue.Count);
        }
    }
}