using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Normal : Mode
{
    public override void SetModeStat()
    {
        ModeStat.MoveSpeed = 1.2f;
        ModeStat.TrackSpeed = 0.5f;
        ModeStat.DelayTime = 2.4f;
    }
}
