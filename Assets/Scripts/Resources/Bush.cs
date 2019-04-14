using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Resources
{
    class Bush : MonoBehaviour, IGatherable
    {
        public GameObject TextMeshObject;
        private TextMesh PointsLabel;

        private float _points = 500;

        
        public GameObject GameObject
        {
            get
            {
                return this.gameObject;
            }
        }


        private void Initiate()
        {
            if (ReferenceManager.Instance != null)
            {
                ReferenceManager.Instance.Gatherables.Add(this);
            }
            else
            {
                Invoke("Initiate", 1);
            }
        }


        private void Start()
        {
            this.Initiate();
            this.PointsLabel = this.TextMeshObject.GetComponent<TextMesh>();
        }


        public float Gather()
        {
            var pointsToSpend = 10;
            this._points -= pointsToSpend;

            if (this._points <= 0)
            {
                this.GetDestroyed();
            }

            this.UpdateText();
            return pointsToSpend;
        }


        private void UpdateText()
        {
            this.PointsLabel.text = "Turnips: " + (int)this._points;
        }


        private void GetDestroyed()
        {
            ReferenceManager.Instance.Gatherables.Remove(this);
            Destroy(this.gameObject);
        }


        public void WashAway(float dmg)
        {
            this._points -= dmg;
            this.UpdateText();
        }

    }
}
