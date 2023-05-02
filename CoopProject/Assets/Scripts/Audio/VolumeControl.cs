using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider _soundsVolume;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private AudioMixer _audioMixer;
    
    private float _minSliderValue = -20f;
    private float _minMasterValume = -80f;
    private string _nameSoundsAudioChannel = "Sounds";
    private string _nameMusicAudioChannel = "Music";

    private void OnEnable()
    {
        _soundsVolume.onValueChanged.AddListener(OnSetSoundsVolume);
        _musicVolume.onValueChanged.AddListener(OnSetMusicVolume);
    }

    private void OnDisable()
    {
        _soundsVolume.onValueChanged.RemoveListener(OnSetSoundsVolume);
        _musicVolume.onValueChanged.RemoveListener(OnSetMusicVolume);
    }

    private void OnSetSoundsVolume(float value)
    {
        _audioMixer.SetFloat(_nameSoundsAudioChannel, value);

        if (_soundsVolume.value < _minSliderValue)
            _audioMixer.SetFloat(_nameSoundsAudioChannel, _minMasterValume);
    }
    
    private void OnSetMusicVolume(float value)
    {
        _audioMixer.SetFloat(_nameMusicAudioChannel, value);

        if (_musicVolume.value < _minSliderValue)
            _audioMixer.SetFloat(_nameMusicAudioChannel, value);
    }
}
