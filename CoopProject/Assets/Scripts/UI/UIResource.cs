using System.Collections.Generic;
using ResourcesColection.Tree;
using ResourcesGame;
using TMPro;
using UnityEngine;

public class UIResource : MonoBehaviour
{
    [SerializeField] private ResourceCollector _resourceCollector;
    [SerializeField] private TextMeshProUGUI _counterTree;
    [SerializeField] private TextMeshProUGUI _counterRock;

    private void OnEnable()
    {
        _counterTree.text = $"{_resourceCollector.CountColection<ResourceTree>()}";
        _counterRock.text = $"{_resourceCollector.CountColection<ResourceRock>()}";
    }
    
}
