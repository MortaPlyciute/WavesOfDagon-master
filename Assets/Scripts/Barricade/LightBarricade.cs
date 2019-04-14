using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Barricade
{
    class LightBarricade : MonoBehaviour, IBarricade
    {
        private float WaveResistance = 5;

        public float Cost
        {
            get
            {
                return 50;
            }
        }

        public float ResistWave(float power)
        {
            var returnValue = this.WaveResistance >= power ? power : this.WaveResistance;
            this.WaveResistance -= power;

            if (this.WaveResistance <= 0)
            {
                Destroy(this.gameObject);
            }

            if (returnValue < 0)
            {
                returnValue = 0;
            }

            return returnValue;
        }
    }
}
