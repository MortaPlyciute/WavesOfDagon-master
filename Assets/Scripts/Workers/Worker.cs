using Assets.Scripts.Extensions;
using Assets.Scripts.Global;
using Assets.Scripts.Points;
using Assets.Scripts.Resources;
using Assets.Scripts.TimeManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Waves
{
    public class Worker : MonoBehaviour
    {
        const float GatheringDistance = 2f;

        public bool IsWalking
        {
            get
            {
                return _target != null;
            }
        }


        public bool IsGathering
        {
            get
            {
                return this._targetAsGatherable != null && Vector3.Distance(this._target.transform.position, this.transform.position) < GatheringDistance;
            }
        }

        NavMeshAgent _navMesh;

        GameObject _target = null;
        IGatherable _targetAsGatherable = null;

        private float _gatheringCooldown = 0.5f;
        private float _lastGathered = 0;

        // Use this for initialization
        void Start()
        {
            this._navMesh = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {

            if (this._target == null)
            {
                this._targetAsGatherable = ReferenceManager.Instance.Gatherables.CustomFirstOrDefault();
                if (this._targetAsGatherable != null)
                {
                    this._target = this._targetAsGatherable.GameObject;
                }
            }

            if (this._target != null)
            {
                var distance = Vector3.Distance(this._target.transform.position, this.transform.position);
                if (distance > GatheringDistance)
                {
                    this._navMesh.destination = this._target.transform.position;
                    //Todo: Turn to that object
                }
                else
                {
                    this._navMesh.destination = this.transform.position;
                    this.TryFram();
                }
            }

        }


        private void TryFram()
        {
            if (this._lastGathered + this._gatheringCooldown < TimeManager.TimeElapsed)
            {
                this._lastGathered = TimeManager.TimeElapsed;

                var gatheredResources = this._targetAsGatherable.Gather();
                //Debug.Log(gatheredResources);
                IslandResources.Instance.Resources += gatheredResources;
            }
        }

    }
}