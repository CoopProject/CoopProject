using System;
using DefaultNamespace;
using UnityEngine;

public class BackgoundSound : MonoBehaviour
{
  [SerializeField] private AudioSource _audio;

  private void OnEnable()
  {
    GamePause.OnGamePause += AudioStop;
    GamePause.OffGamePause += AudioPlay;
  }

  public void AudioStop() => _audio.Pause();
  
  private void AudioPlay() => _audio.Play();

  private void OnDisable()
  {
    GamePause.OnGamePause -= AudioStop;
    GamePause.OnGamePause -= AudioPlay;
  }
}
