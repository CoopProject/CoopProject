public class IronPresenter
{
    private IronModel _model;
    private IronView _view;
    private ResourceCollector _resourceCollector;

    public IronPresenter(IronModel model, IronView view,ResourceCollector ResourceCollector)
    {
        _model = model;
        _view = view;
        _resourceCollector = ResourceCollector;
            
        _model.OnSetCount += _view.SetValueCount;
        _model.ReadySumResource += _view.SetPriceButton;
            
        _model.SetStartData(_resourceCollector);
    }
}