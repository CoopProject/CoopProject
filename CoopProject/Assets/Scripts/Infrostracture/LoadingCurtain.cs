using System.Collections;
using UnityEngine;

public interface LoadingCurtain
{
    Coroutine StartCoroutine(IEnumerator coroutine);
}