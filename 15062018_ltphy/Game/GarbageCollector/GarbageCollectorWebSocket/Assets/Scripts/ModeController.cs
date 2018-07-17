using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour {
    int type = 0;
    // Use this for initialization
    void Start () {
        if (SettingStat.Mode != null)// if the mode is already available then set suitable type
        {
            if (SettingStat.Mode.GetType() == typeof(Normal))
            {
                type = 0;
            }
            else if (SettingStat.Mode.GetType() == typeof(Hard))
            {
                type = 1;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ChangeMode()
    {
        if (type == 0)
        {
            SettingStat.Mode = new Normal();
        }
        else
        {
            SettingStat.Mode = new Hard();
        }
        SettingStat.Mode.SetModeStat();//to change the setting of each mode.
    }
    public void OnModeClicked(int t)
    {
        type = t;
    }
    public void OnBackClick()
    {

        ChangeMode();
       // Debug.Log("go Here");
    }
}
