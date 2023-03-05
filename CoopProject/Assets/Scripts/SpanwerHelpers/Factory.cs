using System;
using System.Collections.Generic;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection;
using UnityEngine;

namespace SpanwerHelpers
{
    public abstract class Factory<T>: MonoBehaviour where T : Resource
    {
        [SerializeField] private Helper _helperPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] protected T _resource;
        [SerializeField] protected TreeKeeper _treeKeeper;

        protected Helper GetHelperInstantiate()
        {
            var instantiateHelper = Instantiate(_helperPrefab, _spawnPoint.position, Quaternion.identity);
            return instantiateHelper;
        }
    }
}