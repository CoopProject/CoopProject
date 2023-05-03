using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoScrollStore : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;

    private float _setValue = 1;

    private void OnEnable()
    {
        StartCoroutine(OnSetVlaue());
    }

    private IEnumerator OnSetVlaue()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.1f);
        yield return waitTime;
        _scrollbar.value = _setValue;
    }
}
