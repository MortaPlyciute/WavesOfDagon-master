using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Gods
{
    class GodManager : MonoBehaviour
    {
        public static GodManager Instance;

        public God RightGod;
        public God LeftGod;
        public God TopGod;
        public God BottomGod;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public God GetGodByVector(Vector3 position)
        {
            var absX = Math.Abs(position.x);
            var absY = Math.Abs(position.z);

            if (absX >= absY)
            {
                if (position.x >= 0)
                {
                    return RightGod;
                }
                else
                {
                    return LeftGod;
                }
            }
            else
            {
                if (position.z >= 0)
                {
                    return TopGod;
                }
                else
                {
                    return BottomGod;
                }
            }
        }


        public void ShowGod(Vector3 position)
        {
            var god = this.GetGodByVector(position);
            god.Show();
        }

    }
}
