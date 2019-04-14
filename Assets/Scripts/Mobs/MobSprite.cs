using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Mobs
{
    class MobSprite : MonoBehaviour
    {
        public GameObject Mob;

        void Update()
        {
            this.transform.position = Mob.transform.position;
        }
    }
}
