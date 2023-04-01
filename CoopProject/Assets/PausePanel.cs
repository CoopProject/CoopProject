using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private bool _iActive = false;
    
    public bool IActive => _iActive;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        _iActive = true;
        gameObject.SetActive(true);
    }

    public void DisablePanel()
    {
        _iActive = false;
        gameObject.SetActive(false);
    }
}
