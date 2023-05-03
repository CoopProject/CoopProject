using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceen : MonoBehaviour
{
    [SerializeField] private Image _iconLoading;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private RectTransform _transformIcon;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _water;
    [SerializeField] private StartLearningControl _startLerningControl;
    [SerializeField] private TMP_Text _timeLoadText;
 
    private float _durationStartGame = 30f;

    private void Start()
    {
#if UNITY_EDITOR
        _durationStartGame = 0;
#endif
        _backgroundSound.Stop();
        _animator.GetComponent<Animator>();
        _animator.Play("Loading");
        StartCoroutine(StartGame());
        _water.gameObject.SetActive(false);
    }

    private IEnumerator StartGame()
    {
        var WaitForSecondsRealtime = new WaitForSecondsRealtime(1f);

        while (_durationStartGame >= 0)
        {
            _timeLoadText.text = _durationStartGame.ToString();
            _durationStartGame -= 1f;
            yield return WaitForSecondsRealtime;
        }

        _backgroundSound.Play();
        _water.gameObject.SetActive(true);
        _startLerningControl.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}