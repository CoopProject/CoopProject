using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.MVP.MVPShop.Viues
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _background;
        [SerializeField] private TextMeshProUGUI _text;

        public event Action OnUpdate;

        private void LateUpdate()
        {
            OnUpdate?.Invoke();
        }

        public void SetValue(int value)
        {
            if (value > 0)
            {
                _text.text = $"{value}";
                _image.enabled = true;
                _text.enabled = true;
                _background.enabled = true;
            }
            else
            {
                _image.enabled = false;
                _text.enabled = false;
                _background.enabled = false;
            }
        }
    }
}