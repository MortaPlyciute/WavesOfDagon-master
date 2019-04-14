using Assets.Scripts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Global
{
    public enum ConstructableBuilding
    {
        None,
        Barricade,
        Farm
    }

    class ReferenceManager : MonoBehaviour
    {
        public static ReferenceManager Instance;

        public Text ResourceTextLabel;

        public List<IGatherable> Gatherables = new List<IGatherable>();

        public ConstructableBuilding BuildingToBeConstructed = ConstructableBuilding.None;

        public bool IsDebugMode = false;

        private void Start()
        {
            Physics.IgnoreLayerCollision(8, 8, true); //Waves and waves
            Physics.IgnoreLayerCollision(8, 11, true); // Waves and workers
            Physics.IgnoreLayerCollision(11, 11, true); // Workers and other workers (WC3 ftw)

            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            //Todo: Point system here
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="building"></param>
        /// <returns>Returns wether the building was set or canceled out</returns>
        public bool SetBuildingToConstruct(ConstructableBuilding building)
        {
            if (building == this.BuildingToBeConstructed)
            {
                this.BuildingToBeConstructed = ConstructableBuilding.None;
                return false;
            }
            else
            {
                this.BuildingToBeConstructed = building;// ConstructableBuilding.Building;
                return true;
            }
        }

    }
}
