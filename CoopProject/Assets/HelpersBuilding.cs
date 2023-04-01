using UnityEngine;

public class HelpersBuilding : MonoBehaviour
{
    [SerializeField] private SpawnHelperTree _spawnHelperTree;
    [SerializeField] private int _level = 0;
    
    public int Counter => _spawnHelperTree.CounterInstance;
    public int Level => _level;

    public void Lvlup()
    {
        _spawnHelperTree.Instance();
        _level++;
    }
}
