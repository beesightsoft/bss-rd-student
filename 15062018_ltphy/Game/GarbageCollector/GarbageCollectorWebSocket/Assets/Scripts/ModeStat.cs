using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ModeStat  {

    private static float moveSpeed = 2.4f; //move speed of enemy 2.4
    private static float trackSpeed = 0.5f; //track speed 0.5f
    private static float delayTime = 2.2f;// time to spawn enemy 2.2f
    public static float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }

    public static float TrackSpeed
    {
        get
        {
            return trackSpeed;
        }

        set
        {
            trackSpeed = value;
        }
    }

    public static float DelayTime
    {
        get
        {
            return delayTime;
        }

        set
        {
            delayTime = value;
        }
    }
}
