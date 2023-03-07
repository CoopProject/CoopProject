

public class IronPresenter 
{
    private IronModel _model;
    private IronViue _viue;
        
    public IronPresenter(IronModel model,IronViue viues)
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
