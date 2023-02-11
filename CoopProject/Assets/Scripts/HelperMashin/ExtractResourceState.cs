using System;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

namespace HelperMashin
{
    public class ExtractResourceState : MonoBehaviour , IStateHelper
    {
        private HelperStateMashin _helperStateMashin;
        private float _extractDuration = 1f;
        private Collider[] _hits = new Collider[1];
        private float _radius = 2f;
        private int _layerMask;

        [Inject]
        private void Construct(Container container)
        {
            _helperStateMashin = container.Resolve<HelperStateMashin>();
        }

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Resource");
        }

        private void LateUpdate()
        {
            _extractDuration -= Time.deltaTime;
        
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, _layerMask))
            {
                if (_extractDuration < 0 && Hit() > 0)
                {
                    _hits[0].GetComponent<ResourceTree>().TakeDamage();
                }
                else
                {
                    _helperStateMashin.Enter<MoveStateHelper>();
                }

            }
        }
        
        private int Hit()
        {
            return  Physics.OverlapSphereNonAlloc(transform.position + transform.forward, _radius, _hits, _layerMask);
        }

        public void Enter()
        {
            enabled = true;
        }

        public void Exit()
        {
            enabled = false;
        }
    }
}