using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Barricade
{
    interface IBarricade
    {
        float Cost { get; }

        float ResistWave(float power);
    }
}
