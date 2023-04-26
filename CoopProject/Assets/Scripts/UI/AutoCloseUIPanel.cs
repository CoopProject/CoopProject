using System.Collections.Generic;
using UnityEngine;

public class AutoCloseUIPanel : MonoBehaviour
{
    [SerializeField] private List<OpenUIPanel> _openUIPanels;

    private GameObject _currentOpenPanel;

    private void OnEnable()
    {
        foreach (var panel in _openUIPanels)
        {
            panel.PanelOpen += SetCurrentOpenPanel;
        }
    }

    private void OnDisable()
    {
        foreach (var panel in _openUIPanels)
        {
            panel.PanelOpen -= SetCurrentOpenPanel;
        }
    }
    
    private void SetCurrentOpenPanel(GameObject panel)
    {
        if (_currentOpenPanel != null & panel != _currentOpenPanel)
            _currentOpenPanel.GetComponent<OpenUIPanel>().Close();

        _currentOpenPanel = panel;
    }
}


