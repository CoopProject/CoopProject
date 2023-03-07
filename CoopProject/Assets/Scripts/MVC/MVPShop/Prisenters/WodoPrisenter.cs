namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class WodoPrisenter
    {
        private WodoModel _model;
        private WodoViues _viue;
        
        public WodoPrisenter(WodoModel model,WodoViues viues)
        {
            _model = model;
            _viue = viues;
        }

        public void Start()
        {
            _model.SetValueCount(0);
            _viue.SetValueCount(_model.CountElements);
        }

    }
}