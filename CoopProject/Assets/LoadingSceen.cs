using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceen : MonoBehaviour
{
    [SerializeField] private Image _iconLoading;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private RectTransform _transformIcon;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _joustic;

    private float _durationStartGame = 45f;

    private void Start()
    {
        _backgroundSound.Stop();
        _animator.GetComponent<Animator>();
        _animator.Play("Loading");
        StartCoroutine(StartGame());
        _joustic.gameObject.SetActive(false);
    }

    private IEnumerator StartGame()
    {
        var WaitForSecondsRealtime = new WaitForSecondsRealtime(1f);
        while (_durationStartGame >= 0)
        {
            _durationStartGame -= 1f;
            yield return WaitForSecondsRealtime;
        }
        _backgroundSound.Play();
        _joustic.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}