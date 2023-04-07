using System.Collections.Generic;
using UnityEngine;

public class PlayerStepsSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _steps;
    [SerializeField] private AudioSource _stepsPlayer;
    
    public void Play()
    {
        int index = Random.Range(0, _steps.Count);
        _stepsPlayer.PlayOneShot(_steps[index]);
    }
}
