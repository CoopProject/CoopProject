using System;
using System.Collections.Generic;
using ResourcesColection;
using SpanwerHelpers;
using UnityEngine;

namespace DefaultNamespace.Buildings
{
    public class HelperBuildng<T> : MonoBehaviour where T : ResourceSource
    {
        [SerializeField] protected Factory<T> _spawnHelperTree;
        [SerializeField] protected List<ResourceSource> _list;
        [SerializeField] protected UpgradePanelUI<T> _panel;

        public int Counter => _spawnHelperTree.InstanceCount;

        private void Start()=> Lvlup(_panel.LevelUps[_panel.LevelNow].InstanceHelpers, _panel.LevelUps[_panel.LevelNow].ExtractedResources);
        

        public void Lvlup(int helperInstance, int resourceExtraction)
        {
            while (Counter <= helperInstance - 1)
            {
                var helper = _spawnHelperTree.GetHelperInstantiate();
                helper.SetList(_list);
            }

            LevelUpExtraction(resourceExtraction);
        }

        private void LevelUpExtraction(int extraction)
        {
            for (int i = 0; i < _list.Count; i++)
                _list[i].AddResourceCount(extraction);
        }
    }
}