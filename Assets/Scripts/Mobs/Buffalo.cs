using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Mobs
{
    class Buffalo : MonoBehaviour
    {
        private NavMeshAgent _nav;

        public List<Vector3> NavPoints;

        private static System.Random _r = new System.Random();

        void Start()
        {
            this._nav = this.GetComponent<NavMeshAgent>();
            this._nav.destination = this.NavPoints[_r.Next(this.NavPoints.Count)];
        }

        void Update()
        {
            if (this._nav.pathStatus == NavMeshPathStatus.PathComplete)
            {
                this._nav.destination = this.NavPoints[_r.Next(this.NavPoints.Count)];
            }
        }

    }
}
