using UnityEngine;

public class GoldPresenter
{
    private GoldModel _model;
    private GoldViue _viue;

    public GoldPresenter(GoldModel model, GoldViue viues)
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