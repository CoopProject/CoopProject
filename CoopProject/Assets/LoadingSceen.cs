using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceen : MonoBehaviour
{
    [SerializeField] private Image _iconLoading;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private RectTransform _transformIcon;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _joustic;
    [SerializeField] private GameObject _water;
    [SerializeField] private StartLerningControl _startLerningControl;
 
    private float _valueFade = 0;
    private float _durationStartGame = 30f;
    private float _spead = 1f;

    private void Awake()
    {
        _startLerningControl.gameObject.SetActive(false);
    }

    private void Start()
    {
        _backgroundSound.Stop();
        _animator.GetComponent<Animator>();
        _animator.Play("Loading");
        StartCoroutine(StartGame());
        _joustic.gameObject.SetActive(false);
        _water.gameObject.SetActive(false);
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
        _water.gameObject.SetActive(true);
        _startLerningControl.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}