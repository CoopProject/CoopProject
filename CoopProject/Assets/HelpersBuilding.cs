using UnityEngine;

public class HelpersBuilding : MonoBehaviour
{
    [SerializeField] private SpawnHelperTree _spawnHelperTree;
    [SerializeField] private int _level = 0;

    private int _nexLevel;
    public int NextLevel => _nexLevel;
    public int Counter => _spawnHelperTree.CounterInstance;
    public int Level => _level;
    private void Start()
    {
        _nexLevel  = _level + 1;
    }

    private void Lvlup()
    {
        _spawnHelperTree.Instance();
    }
}
