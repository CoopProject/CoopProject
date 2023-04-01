using System.Collections;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

namespace ResourcesColection.Gold_Ore
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(BoxCollider))]
    public class GoldOre : ResourceSource, IResourceSource
    {
        private int _maxHealth = 10;
        private int _health = 30;
        private float _durationReset = 10f;
        private ResourceCollector _resourceCollector;
        private int _resourceAddCount;

        [Inject]
        private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();

        private void Awake()
        {
            _mesh = GetComponent<MeshRenderer>();
            _colliderBox = GetComponent<BoxCollider>();
        }

        public override void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Dead();
                _iDead = true;
                AddResource();
                StartCoroutine(Reset());
            }
        }
        
        private void AddResource()
        {
            for (int i = 0; i < _resourceAddCount; i++)
            {
                Gold gold = new();
                gold.SetPrice();
                _resourceCollector.AddResource<Gold>(gold);   
            }
        }
        
        public void AddResourceCount() => _resourceAddCount++;

        private IEnumerator Reset()
        {
            var waitForSecondsRealtime = new WaitForSecondsRealtime(_durationReset);
            yield return waitForSecondsRealtime;
            _iDead = false;
            _health = _maxHealth;
            _mesh.enabled = true;
            _colliderBox.enabled = true;
        }
    }
}