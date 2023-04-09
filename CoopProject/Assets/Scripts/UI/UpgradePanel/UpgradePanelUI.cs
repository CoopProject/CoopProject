using System;
using System.Collections.Generic;
using DefaultNamespace.UI.UpgradePanel;
using Reflex;
using Reflex.Scripts.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public abstract class UpgradePanelUI : MonoBehaviour
{
    [SerializeField] private HelpersBuildingTree _helpersBuilding;
    [SerializeField] private TextMeshProUGUI _levelUpNow;
    [SerializeField] private Button _buttonLvlUp;
    [SerializeField] private TextMeshProUGUI _countHelperInstance;
    [SerializeField] private TextMeshProUGUI _nextCountSpawnHelper;
    [SerializeField] private TextMeshProUGUI _extraction;
    [SerializeField] private TextMeshProUGUI _valumeExtraction;
    [SerializeField] private TextMeshProUGUI _buttonPrice;
    [SerializeField] private List<LevelUpData> _levelUps;

    private int _levelNow = 0;
    private void Start()
    {
        _levelUpNow.text = $"{_levelNow + 1}";
        _countHelperInstance.text = $"{_levelUps[_levelNow].InstanceHelpers}";
        _nextCountSpawnHelper.text = $"{_levelUps[_levelNow + 1].InstanceHelpers}";
        _extraction.text = $"{_levelUps[_levelNow].ExtractedResources}";
        _valumeExtraction.text = $"{_levelUps[_levelNow + 1].ExtractedResources}";

    }
}