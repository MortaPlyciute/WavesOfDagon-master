using Assets.Scripts.Global;
using Assets.Scripts.Gods;
using Assets.Scripts.TimeManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Waves
{
    class WaveSpawner : MonoBehaviour
    {
        const float WaveSpawnDistance = 50f;

        private float _lastWaveSpawned = -10;
        private float _waveCooldown = 10;

        private static System.Random _random = new System.Random();

        void Start()
        {

        }


        void Update()
        {
            if (this._lastWaveSpawned + this._waveCooldown < TimeManager.TimeElapsed)
            {
                this.SpawnWave();
            }
        }


        private void SpawnWave()
        {
            var waveStrength = 4f;
            waveStrength += TimeManager.TimeElapsed / (this._waveCooldown * 2);

            Vector3 spawnDirection = new Vector3(this.GetRandomVectorCoord(), 0, this.GetRandomVectorCoord());
            spawnDirection.Normalize();

            if (_random.Next(10) > 3)
            {
                waveStrength *= 2;
                GodManager.Instance.ShowGod(spawnDirection);
            }


            Vector3 spawnPosition = Vector3.zero + spawnDirection * WaveSpawnDistance;
            spawnPosition.y = 1f;
            Vector3 perpendicular = this.GetPerpendicular(spawnDirection);

            var waveAmmount = _random.Next((int)waveStrength / 2, (int)waveStrength * 2);

            for (float i = -(waveAmmount / 2); i < waveAmmount / 2; i++)
            {
                var wavePosition = spawnPosition + perpendicular * i;
                var spawnedWave = PrefabManager.Instance.CreateWave(wavePosition, null);

                var wave = spawnedWave.GetComponent<Wave>();
                wave.Power = waveStrength / 20;
                wave.Speed += waveStrength / 10;

                spawnedWave.transform.LookAt(Vector3.zero);
            }
            this._lastWaveSpawned = TimeManager.TimeElapsed;

        }


        private Vector3 GetPerpendicular(Vector3 vector)
        {
            vector.Normalize();
            Vector3 side = Vector3.Cross(vector, -transform.right);
            return Vector3.Cross(vector, side);
        }


        private float GetRandomVectorCoord()
        {
            var randFloat = (float)_random.NextDouble();
            randFloat = randFloat * 2;
            randFloat -= 1;
            return randFloat;
        }

    }
}
