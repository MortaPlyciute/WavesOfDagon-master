using Assets.Scripts.Global;
using Assets.Scripts.Points;
using Assets.Scripts.Waves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Land
{
    class Sand : MonoBehaviour
    {
        public void OnTriggerEnter(Collider collider)
        {
            Wave otherAsWave = collider.GetComponent<Wave>();
            if (otherAsWave != null)
            {
                otherAsWave.Beached();
            }
        }


        void OnMouseDown()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);
                var building = ReferenceManager.Instance.BuildingToBeConstructed;
                var pointToSpawn = hit.point;
                pointToSpawn.y = 0.33f;
                switch (building)
                {
                    case ConstructableBuilding.None:
                        break;
                    case ConstructableBuilding.Barricade:
                        if (ReferenceManager.Instance.IsDebugMode || IslandResources.Instance.Resources >= 50)
                        {
                            IslandResources.Instance.Resources -= 50;
                            PrefabManager.Instance.CreateBarricade(pointToSpawn, null);
                        }
                        break;
                    case ConstructableBuilding.Farm:
                        if (ReferenceManager.Instance.IsDebugMode ||  IslandResources.Instance.Resources >= 100)
                        {
                            IslandResources.Instance.Resources -= 100;
                            PrefabManager.Instance.CreateFarm(pointToSpawn, null);
                        }
                        break;
                    default:
                        break;
                }

            }
        }

    }
}
