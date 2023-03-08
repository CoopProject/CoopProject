using System;
using UnityEngine;

namespace ResourcesGame.TypeResource
{
    public class Log : MonoBehaviour, IResource
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ResourceCollector collector))
            {
                gameObject.SetActive(false);
            }
        }
    }
}