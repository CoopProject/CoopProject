using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _steps;
    [SerializeField] private AudioSource _stepsPlayer;
    [SerializeField] private AudioSource _miningSound;
    
    public void PlayStepSound()
    {
        int index = Random.Range(0, _steps.Count);
        _stepsPlayer.PlayOneShot(_steps[index]);
    }

    public void PlayMiningSound()
    {
        _miningSound.Play();
    }
}
