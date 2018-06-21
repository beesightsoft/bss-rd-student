using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    // Use this for initialization
     GameObject[] gosEarth;
     GameObject[] gosSpace;
    string mode;
    void setEarthActive(bool active)
    {
        foreach (GameObject go in gosEarth)
        {
            go.SetActive(active);
        }
    }
    void setSpaceActive(bool active)
    {
        foreach (GameObject go in gosSpace)
        {
            go.SetActive(active);
        }
    }
    void  enableArrow()
    {
        if (PlayerPrefs.HasKey("Mode"))
        {
            mode = PlayerPrefs.GetString("Mode");
        }
        else
        {
            mode = "Earth";
        }
        gosEarth = GameObject.FindGameObjectsWithTag("btnEarth");
        gosSpace = GameObject.FindGameObjectsWithTag("btnSpace");
        
        if (mode.Equals("Earth"))
        {
            setEarthActive(true);
            setSpaceActive(false);
        }
        else if (mode.Equals("Space"))
        {
            setEarthActive(false);
            setSpaceActive(true);
        }
    }
	void Start () {
        enableArrow();
	}

    // Update is called once per frame
    void Update()
    {

    }
}
