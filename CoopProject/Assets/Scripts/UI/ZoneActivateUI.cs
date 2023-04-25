using UnityEngine;

public class ZoneActivateUI : MonoBehaviour
{
    [SerializeField] private ButtonOpenUI _openUI;
    private void OnTriggerEnter(Collider сollider)
    {
        if (сollider.TryGetComponent(out Player player))
            _openUI.Open();
    }

    private void OnTriggerExit(Collider сollider)
    {
        if (сollider.TryGetComponent(out Player player))
            _openUI.Close();
    }
}
