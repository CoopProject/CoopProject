using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            button.onClick.AddListener(Play);
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.onClick.RemoveListener(Play);
        }
    }

    private void Play()
    {
        _audioSource.Play();
    }
}
