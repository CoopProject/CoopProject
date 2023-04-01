using SpanwerHelpers;


internal class SpawnHelperTree : Factory<Tree>
{
    private Helper _helper;
    private int _counterInstance = 0;

    public int CounterInstance => _counterInstance;

    public void Instance()
    {
        _counterInstance++;
        _helper = GetHelperInstantiate();
        _helper.SetList<Tree>(_treeKeeper);
    }
}
