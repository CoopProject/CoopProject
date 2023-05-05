using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartLearningControl : MonoBehaviour
{
    [SerializeField] private SetterComponentsActivity _componentsActivity;
    [SerializeField] private List<Transform> _cameraPoints;
    [SerializeField] private List<GameObject> _learnCards;
    [SerializeField] private float _timeCameraMove = 1.0f;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _skipButton;
    [SerializeField] private Transform _playerPoint;

    private Vector3 _endPoint;
    private Vector3 _offset = new Vector3(0, 10, -8);
    private int _index = 0;
    private string _nameSave = "LearningProgress";

    private void OnEnable()
    {
        _endPoint = _playerPoint.position + _offset;
        _nextButton.onClick.AddListener(SetNextView);
        _skipButton.onClick.AddListener(SkipLearn);
        LoadData();
        SetNextView();
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(SetNextView);
        _skipButton.onClick.RemoveListener(SkipLearn);
    }

    public void EndLearning()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(Camera.main.transform.DOLocalMove(_endPoint, _timeCameraMove));
        sequence.Insert(0, Camera.main.transform.DORotate(_cameraPoints[_cameraPoints.Count - 1].rotation.eulerAngles, _timeCameraMove));
        StartCoroutine(OnPlayDelay());
    }

    private void SetNextView()
    {
        if (_index < _cameraPoints.Count - 1)
        {
            Camera.main.transform.DOMove(_cameraPoints[_index].position, _timeCameraMove);
            Camera.main.transform.DORotate(_cameraPoints[_index].rotation.eulerAngles, _timeCameraMove);
            _index++;
            _learnCards[_index - 1].SetActive(false);
            _learnCards[_index].SetActive(true);
        }
        else
        {
            SaveData();
            EndLearning();
        }
    }

    private void SkipLearn()
    {
        _index = _cameraPoints.Count;
        SaveData();
        EndLearning();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(_nameSave, _index);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey(_nameSave))
            _index = PlayerPrefs.GetInt(_nameSave);
    }

    private IEnumerator OnPlayDelay()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_timeCameraMove);
        yield return waitTime;
        _componentsActivity.EnableComponents();
        enabled = false;
    }
}
