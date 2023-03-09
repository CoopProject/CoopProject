using UnityEngine;

public class GoldPresenter
{
    private GoldModel _model;
    private GoldView _view;
    private ResourceCollector _resourceCollector;

    public GoldPresenter(GoldModel model, GoldView view,ResourceCollector ResourceCollector)
    {
        _model = model;
        _view = view;
        _resourceCollector = ResourceCollector;
            
        _model.OnSetCount += _view.SetValueCount;
        _model.ReadySumResource += _view.SetPriceButton;
            
        _model.SetStartData(_resourceCollector);
    }
}