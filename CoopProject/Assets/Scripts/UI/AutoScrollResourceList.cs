using UnityEngine;
using UnityEngine.UI;

public class AutoScrollResourceList : MonoBehaviour
{
    [SerializeField] private OpenUIPanel _openUIPanel;
    [SerializeField] private Scrollbar _scrollBar;
    
    private float _value = 1.0f;

    private void OnEnable()
    {
        _openUIPanel.PanelOpen += SetView;
    }

    private void OnDisable()
    {
        _openUIPanel.PanelOpen -= SetView;
    }

    private void SetView(GameObject gameObject)
    {
        _scrollBar.value = _value;
    }
}
