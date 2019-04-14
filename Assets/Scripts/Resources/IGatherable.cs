using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Resources
{
    interface IGatherable
    {
        float Gather();
        void WashAway(float dmg);
        GameObject GameObject { get; }
    }
}
