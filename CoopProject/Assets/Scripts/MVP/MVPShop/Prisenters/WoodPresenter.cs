namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class WoodPresenter
    {
        private WoodModel _model;
        private WoodViues _viue;
        
        public WoodPresenter(WoodModel model,WoodViues viues)
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