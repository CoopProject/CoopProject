using System;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class LogsModel
{
    public int CountElements { get; private set; } = 0;
    public int PriceResource { get; private set; }
    public int SumResourceValue { get; private set; } = 0;

    public event Action<int> OnSetCount;
    public event Action<int> ReadySumResource;

    public void SetStartData(ResourceCollector resourceCollector)
    {
        CountElements = resourceCollector.GetCountList<Log>();
        PriceResource = 10;
        OnSetCount?.Invoke(CountElements);
        SumResources();
        ReadySumResource.Invoke(SumResourceValue);
    }
    
    
    private void SumResources()
    {
        for (int i = 0; i < CountElements; i++)
        { 
            SumResourceValue += PriceResource;
        }
    }
}