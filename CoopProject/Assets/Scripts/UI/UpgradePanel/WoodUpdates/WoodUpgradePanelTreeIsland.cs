using System;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class WoodUpgradePanelTreeIsland : UpgradePanelUI<Tree>
{
    private const string _treeIsland = "TreeIsland";
    
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void OnEnable()
    {
        ButtonClick += SaveData;
    }

    private void Awake()
    {
        _levelNow = PlayerPrefs.GetInt(_treeIsland,LevelelNow); 
    }

    private void Start()
    {
        SetData();
        SetNexData();

        _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        _buttonLvlUpReward.onClick.AddListener(ShowReward);
        _buttonLvlUp.onClick.AddListener(LevelUp);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(_treeIsland,LevelelNow);
    }

    private void OnDisable()
    {
        ButtonClick -= SaveData;
    }
}