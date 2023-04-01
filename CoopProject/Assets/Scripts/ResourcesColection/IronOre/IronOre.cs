using System.Collections;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

namespace ResourcesColection.IronOre
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(BoxCollider))]
    public class IronOre : ResourceSource
    {
        private int _maxHealth = 10;
        private int _health = 30;
        private float _durationReset = 10f;
        private ResourceCollector _resourceCollector;

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
                Iron iron = new();
                iron.SetPrice();
                _resourceCollector.AddResource<Iron>(iron);
                StartCoroutine(Reset());
            }
        }

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