using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.MVP.MVPShop.Viues
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        public event Action OnUbdate;

        private void SetValue(int value)
        {
            _text.text = $"{value}";
        }
    }
}