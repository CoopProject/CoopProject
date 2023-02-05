using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly LoadingCurtain _loadingCurtain;

    public SceneLoader(LoadingCurtain loadingCurtain) =>
        _loadingCurtain = loadingCurtain;

    public void Load(int scenNumber, Action onLoaded = null) =>
        _loadingCurtain.StartCoroutine(LoadSceen(scenNumber, onLoaded));
    
    public IEnumerator LoadSceen(int sceneNumber, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
            onLoaded?.Invoke();
            yield break;
        }
        
        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneNumber);

        while (!waitNextScene.isDone)
        {
            yield return null;
        }
        onLoaded?.Invoke();
    }
}