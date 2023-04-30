using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartLerningControl : MonoBehaviour
{
    [SerializeField] private SetterComponentsActivity _componentsActivity;
    [SerializeField] private List<Transform> _cameraPoints;
    [SerializeField] private List<GameObject> _learnCards;
    [SerializeField] private float _timeCameraMove = 1.0f;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _skipButton;
    
    private int _index = 0;

    private void OnEnable()
    {
        _nextButton.onClick.AddListener(SetNextView);
        _skipButton.onClick.AddListener(EndLerning);
        SetNextView();
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(SetNextView);
        _skipButton.onClick.AddListener(EndLerning);
    }
    
    private void SetNextView()
    {
        if (_index != _cameraPoints.Count)
        {
            Camera.main.transform.DOMove(_cameraPoints[_index].position, _timeCameraMove);
            Camera.main.transform.DORotate(_cameraPoints[_index].rotation.eulerAngles, _timeCameraMove);
            _index++;
            _learnCards[_index - 1].SetActive(false);
            _learnCards[_index].SetActive(true);
        }
        else
        {
            EndLerning();
        }
    }
    
    private void EndLerning()
    {
        _componentsActivity.EnableComponents();
        enabled = false;
    }
}
