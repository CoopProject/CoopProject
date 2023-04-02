using System;
using Reflex;
using Reflex.Scripts.Attributes;
using TMPro;
using UnityEngine;

public class OpenIslandPanel : MonoBehaviour
{
    [SerializeField] private IslandBridge _islandBridge;
    [Header("Счетчики ресурсов")]
    [SerializeField] private TextMeshProUGUI _textCounterCoin;
    [SerializeField] private TextMeshProUGUI _textCounterResourceOne;
    [SerializeField] private TextMeshProUGUI _textCounterResourceTwo;
    [Space]
    [SerializeField] private int MaxCountCountCoin = 10;
    [Space]
    [SerializeField] private int MaxCountCountOne = 15;
    [Space]
    [SerializeField] private int MaxCountCountTwo = 20;

    private int CountCoin = 0;
    private int CountResourceOne = 0;
    private int CountResourceTwo = 0;
    private ResourceCollector _resourceCollector;
    private Player _player;

    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }

    private void Start()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountCountOne}";
        _textCounterResourceTwo.text = $"{CountResourceTwo}/{MaxCountCountTwo}";
    }
}
