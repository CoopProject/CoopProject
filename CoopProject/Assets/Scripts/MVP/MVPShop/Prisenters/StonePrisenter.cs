public class StonePrisenter
{
    private StoneModel _model;
    private StoneView _view;
    private ResourceCollector _resourceCollector;
    
    public StonePrisenter(StoneModel model, StoneView view,ResourceCollector ResourceCollector)
    {
        _model = model;
        _view = view;
        _resourceCollector = ResourceCollector;
            
        _model.OnSetCount += _view.SetValueCount;
        _model.ReadySumResource += _view.SetPriceButton;
            
        _model.SetStartData(_resourceCollector);
    }
}