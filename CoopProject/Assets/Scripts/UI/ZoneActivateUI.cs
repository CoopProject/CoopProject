using UnityEngine;
using UnityEngine.Serialization;

public class ZoneActivateUI : MonoBehaviour
{
    [FormerlySerializedAs("_openUI")] [SerializeField] private OpenUIPanel _openUIPanel;
    private void OnTriggerEnter(Collider сollider)
    {
        if (сollider.TryGetComponent(out Player player))
            _openUIPanel.Open();
    }

    private void OnTriggerExit(Collider сollider)
    {
        if (сollider.TryGetComponent(out Player player))
            _openUIPanel.Close();
    }
}
