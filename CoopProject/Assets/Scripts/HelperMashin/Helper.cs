using System.Collections;
using HelperMashin;
using UnityEngine;

public class Helper : HelperStateMachine, IHelper
{
    private int _damage;
    private void Start()
    {
        StartCoroutine(StartWork());
    }


    private IEnumerator StartWork()
    {
        yield return new WaitForSecondsRealtime(1f);
        Enter<MoveStateHelper>();
    }
}