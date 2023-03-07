using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronPrisenter : MonoBehaviour
{
    private IronModel _model;
    private IronViue _viue;
        
    public IronPrisenter(IronModel model,IronViue viues)
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
