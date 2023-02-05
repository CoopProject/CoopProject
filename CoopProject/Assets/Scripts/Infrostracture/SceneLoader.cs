using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) =>
        _coroutineRunner = coroutineRunner;

    public void Load(int scenNumber, Action onLoaded = null) =>
        _coroutineRunner.StartCoroutine(LoadSceen(scenNumber, onLoaded));
    
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