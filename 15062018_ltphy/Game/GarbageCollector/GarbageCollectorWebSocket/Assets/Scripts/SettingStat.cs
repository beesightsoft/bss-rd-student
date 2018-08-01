using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class SettingStat{

    private static bool isSound = true;
    private static bool isNormal = true;
    private static String serverURL = "localhost:9000";
    private static String prevScene = "Menu"; //store the previous scene for onBack function
    private static Mode mode = new Normal();

    public static bool IsSound
    {
        get
        {
            return isSound;
        }

        set
        {
            isSound = value;
        }
    }

    public static bool IsNormal
    {
        get
        {
            return isNormal;
        }

        set
        {
            isNormal = value;
        }
    }

    public static string ServerURL
    {
        get
        {
            return serverURL;
        }

        set
        {
            serverURL = value;
        }
    }

    public static string PrevScene
    {
        get
        {
            return prevScene;
        }

        set
        {
            prevScene = value;
        }
    }

    internal static Mode Mode
    {
        get
        {
            return mode;
        }

        set
        {
            mode = value;
        }
    }
}
