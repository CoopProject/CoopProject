using System.Collections.Generic;
using Reflex;
using UnityEngine;

namespace SpanwerHelpers
{
    public abstract class Factory : MonoBehaviour
    {
        [SerializeField] private Helper _helper;
        [SerializeField] private Transform _spawnPoint;
        public Helper GetHelper()
        {
            var instantiateHelper = Instantiate(_helper, _spawnPoint.position, Quaternion.identity);
            return instantiateHelper;
        }
    }
}