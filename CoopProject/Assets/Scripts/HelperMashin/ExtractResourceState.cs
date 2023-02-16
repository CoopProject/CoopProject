using System;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

namespace HelperMashin
{
    public class ExtractResourceState : MonoBehaviour , IStateHelper
    {
        private HelperStateMachine _helperStateMachine;
        private float _extractDuration = 0.5f;
        private Collider[] _hits = new Collider[1];
        private float _radius = 2f;
        private int _layerMask;

        [Inject]
        private void Construct(Container container)
        {
            _helperStateMachine = container.Resolve<HelperStateMachine>();
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
                    _extractDuration = 0.5f;
                    _hits[0].GetComponent<Tree>().TakeDamage(5);
                }
            }
            else
            {
                _helperStateMachine.Enter<MoveStateHelper>();
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