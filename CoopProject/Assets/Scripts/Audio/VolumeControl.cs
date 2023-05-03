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
    private string _nameSaveSound = "SoundValueSave";
    private string _nameSaveMusic = "MusicValueSave";

    private void OnEnable()
    {
        _soundsVolume.onValueChanged.AddListener(OnSetSoundsVolume);
        _musicVolume.onValueChanged.AddListener(OnSetMusicVolume);  
    }

    private void Start()
    {
        LoadData();
        OnSetSoundsVolume(_soundsVolume.value);
        OnSetMusicVolume(_musicVolume.value);
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

        SaveData(_nameSaveSound, _soundsVolume.value);
    }
    
    private void OnSetMusicVolume(float value)
    {
        _audioMixer.SetFloat(_nameMusicAudioChannel, value);

        if (_musicVolume.value < _minSliderValue)
            _audioMixer.SetFloat(_nameMusicAudioChannel, _minMasterValume);

        SaveData(_nameSaveMusic, _musicVolume.value);
    }

    private void SaveData(string nameSave, float value)
    {
        PlayerPrefs.SetFloat(nameSave, value);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey(_nameSaveSound))
            _soundsVolume.value = PlayerPrefs.GetFloat(_nameSaveSound);

        if (PlayerPrefs.HasKey(_nameSaveMusic))
            _musicVolume.value = PlayerPrefs.GetFloat(_nameSaveMusic);
    }
}
