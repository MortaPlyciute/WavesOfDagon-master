using Assets.Scripts.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Barricade;
using Assets.Scripts.TimeManagment;

namespace Assets.Scripts.Waves
{
    public class Wave : MonoBehaviour
    {

        public float Power = 1;
        public float Speed = 10;

        private bool _onLand = false;
        private float _initialSpeedBeforeLand = 0;
        private Vector3 _beachedPosition;

        List<IGatherable> _gatherablesInWave = new List<IGatherable>();

        Rigidbody _rigidBody;

        // Use this for initialization
        void Start()
        {
            this._rigidBody = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            var direction = (new Vector3(0, 0, 0) - this.transform.position).normalized;
            //this.transform.position = this.transform.position + direction * this.Speed * TimeManager.DeltaTime;
            this._rigidBody.MovePosition(this.transform.position + direction * this.Speed * TimeManager.DeltaTime);

            if (this._onLand)
            {
                if (this.Speed >= 0)
                {
                    this.Speed -= ((this._initialSpeedBeforeLand * 0.2f) + 1.5f) * TimeManager.DeltaTime;
                }
                else
                {
                    this.Speed -= ((this._initialSpeedBeforeLand * 0.2f) + 1.5f) * TimeManager.DeltaTime;
                    //this.Speed -= (-1f / (this.Speed / 3)) * TimeManager.DeltaTime * 0.75f;
                }

                if (Vector3.Distance(this.transform.position, this._beachedPosition - direction * 5) < 1)
                {
                    Destroy(this.gameObject);
                }
            }

            this._rigidBody.velocity = Vector3.zero;

            this.DamageGatherables();
        }

        private void DamageGatherables()
        {
            foreach (var gatherable in this._gatherablesInWave)
            {
                gatherable.WashAway(this.Power * TimeManager.DeltaTime);
            }
        }

        public void Beached()
        {
            this._onLand = true;
            this._initialSpeedBeforeLand = this.Speed;
            this._beachedPosition = this.transform.position;
        }


        public void OnTriggerEnter(Collider collider)
        {
            var otherAsObstacle = collider.gameObject.GetComponent<IBarricade>();
            if (otherAsObstacle != null)
            {
                if (this.Power > 0)
                {
                    var resistedAmmount = otherAsObstacle.ResistWave(this.Power);
                    var resistedPercentage = resistedAmmount / this.Power;
                    this.Power -= resistedAmmount;
                    this.Speed -= this.Speed * resistedAmmount;

                    if (this.Power <= 0)
                    {
                        this.Speed = 0;
                    }
                }
            }

            var gatherable = collider.gameObject.GetComponent<IGatherable>();
            if (gatherable != null && !this._gatherablesInWave.Contains(gatherable))
            {
                this._gatherablesInWave.Add(gatherable);
            }
        }


        public void OnTriggerExit(Collider collider)
        {
            var gatherable = collider.gameObject.GetComponent<IGatherable>();
            if (gatherable != null && this._gatherablesInWave.Contains(gatherable))
            {
                this._gatherablesInWave.Remove(gatherable);
            }
        }


    }
}
