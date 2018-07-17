using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Hard : Mode
{
    public override void SetModeStat()
    {
        ModeStat.MoveSpeed = 3.6f; //car drop time faster than normal 3
        ModeStat.TrackSpeed = 1f;// faster than normal 2 time
        ModeStat.DelayTime =  1.1f;//spawn faster than 2 times
    }
}
