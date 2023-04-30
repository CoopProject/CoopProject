using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenGameLoad : MonoBehaviour
{
    private int _nexSceenNubmer = 1;

    private void Start()
    {
        ScenLoad();
    }


    private void ScenLoad() => SceneManager.LoadScene(_nexSceenNubmer);
    
}
