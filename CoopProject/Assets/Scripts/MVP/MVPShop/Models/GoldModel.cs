public class GoldModel
{
    private ResourceCollector _resourceCollector;
    public int CountElements { get; private set; } = 0;

    public void SetValueCount(int value) => CountElements = value;
}