using System.Collections.Generic;
using ResourcesColection;
using ResourcesGame;
using TMPro;
using UnityEngine;

public class UIResourceRock : MonoBehaviour
{
    [SerializeField] private ShopResource _shopResource;
    [SerializeField] private TextMeshProUGUI _text;

    private List<Resource> _rockColetion;
    private int _sumResourcePrice;

    public int SumResourcePrice => _sumResourcePrice;
    

    private void OnEnable()
    {
        _rockColetion = _shopResource.SetListColection<ResourceRock>();
        _text.text = $"{_rockColetion.Count}";
        SumValueResource();
    }

    private void SumValueResource()
    {
        if (_rockColetion != null)
        {
            foreach (var resource in _rockColetion)
            {
                _sumResourcePrice += resource.Price;
            }
        }
    }

}
