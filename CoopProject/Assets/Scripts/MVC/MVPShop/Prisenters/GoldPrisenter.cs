using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPrisenter : MonoBehaviour
{
    private GoldModel _model;
    private GoldViue _viue;
        
    public GoldPrisenter(GoldModel model,GoldViue viues)
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
