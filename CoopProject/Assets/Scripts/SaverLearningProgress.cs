using UnityEngine;

public class SaverLearningProgress : MonoBehaviour
{
    [SerializeField] private StartLearningControl _learning;
    
    private string _nameSave = "LearningProgress";
    private int _learnState = 0;
    private int _learnEndValue = 1;

    private void Awake()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(_nameSave, _learnEndValue);
    }
    
    private void LoadData()
    {
        PlayerPrefs.GetInt(_nameSave, _learnState);

        if (_learnState == _learnEndValue)
            _learning.EndLearning();
    }
}
