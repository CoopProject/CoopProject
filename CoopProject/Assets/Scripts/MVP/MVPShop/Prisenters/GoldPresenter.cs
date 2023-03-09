

public class GoldPresenter
{
    private GoldModel _model;
    private GoldViue _viue;
        
    public GoldPresenter(GoldModel model,GoldViue viues)
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
