using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePrisenter : MonoBehaviour
{
    private StoneModel _model;
    private StoneViue _viue;
        
    public StonePrisenter(StoneModel model,StoneViue viues)
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
