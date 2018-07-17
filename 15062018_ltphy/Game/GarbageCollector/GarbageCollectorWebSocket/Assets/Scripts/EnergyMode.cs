using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EnergyMode : Mode
{
    public override void SetModeStat()
    {
        ModeStat.MoveSpeed = ModeStat.MoveSpeed;//increase 2 time
        ModeStat.TrackSpeed = ModeStat.TrackSpeed * 1.8f; //increase 1.8 time
        ModeStat.DelayTime = ModeStat.DelayTime * 0.9f; //decrease 0.8
    }
}
