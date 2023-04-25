using System.Collections.Generic;
using UnityEngine;

public class UIPanelControlActivity : MonoBehaviour
{
    [SerializeField] private List<OpenUIPanel> _buttonOpenUI;
    
    private void OnEnable()
    {
        foreach (var item in _buttonOpenUI)
        {
            item.PanelOpen += SetActivity;
        }
    }

    private void OnDisable()
    {
        foreach (var item in _buttonOpenUI)
        {
            item.PanelOpen -= SetActivity;
        }
    }
    
    private void SetActivity()
    {
        
    }
}
