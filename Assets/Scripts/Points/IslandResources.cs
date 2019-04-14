using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Points
{
    class IslandResources
    {
        private float _resources;
        public float Resources
        {
            get
            {
                return this._resources;
            }
            set
            {
                this._resources = value;
                this.UpdateSystem();
            }
        }


        private static IslandResources _instance;

        public static IslandResources Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IslandResources();
                }

                return _instance;
            }
        }


        private IslandResources()
        {
            this.Resources = 0;
        }


        private void UpdateSystem()
        {
            if (ReferenceManager.Instance != null && ReferenceManager.Instance.ResourceTextLabel != null)
            {
                ReferenceManager.Instance.ResourceTextLabel.text = this.Resources.ToString();
            }
        }

    }
}
