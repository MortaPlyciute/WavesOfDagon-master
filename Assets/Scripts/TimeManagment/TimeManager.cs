using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.TimeManagment
{
    class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;

        public float Multiplier = 1;

        private float _timeElapsed;
        public static float TimeElapsed
        {
            get
            {
                return Instance._timeElapsed;
            }
        }


        public static float DeltaTime
        {
            get
            {
                return Time.deltaTime * Instance.Multiplier;
            }
        }


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Instance._timeElapsed = Time.time;
        }


        void Update()
        {
            this._timeElapsed += DeltaTime;
        }

    }
}
