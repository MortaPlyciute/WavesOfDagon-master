using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Global
{
    class PrefabManager : MonoBehaviour
    {
        public static PrefabManager Instance;

        public GameObject FarmPrefab;
        public GameObject BarricadePrefab;
        public GameObject WavePrefab;
        public GameObject WorkerPrefab;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }


        public GameObject CreateBarricade(Vector3 position, Transform parent)
        {
            return this.CreatePrefabObject(this.BarricadePrefab, position, parent);
        }

        public GameObject CreateWorker(Vector3 position, Transform parent)
        {
            return this.CreatePrefabObject(this.WorkerPrefab, position, parent);
        }

        public GameObject CreateFarm(Vector3 position, Transform parent)
        {
            return this.CreatePrefabObject(this.FarmPrefab, position, parent);
        }


        public GameObject CreateWave(Vector3 position, Transform parent)
        {
            return this.CreatePrefabObject(this.WavePrefab, position, parent);
        }


        public GameObject CreatePrefabObject(GameObject prefabObject, Vector3 position, Transform parent)
        {
            GameObject returnObject;
            if (parent != null)
            {
                returnObject =
                    MonoBehaviour.Instantiate(prefabObject, parent) as GameObject;
            }
            else
            {
                returnObject =
                    MonoBehaviour.Instantiate(prefabObject) as GameObject;
            }

            if (returnObject == null)
            {
                throw new ArgumentNullException("prefabObject");
            }

            returnObject.transform.localPosition = position;

            return returnObject;
        }

    }
}
