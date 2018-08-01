using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    // Use this for initialization
     GameObject[] gosEarth;
     GameObject[] gosSpace;
    string mode;
    void setActive(bool active,GameObject[] gosList)
    {
        foreach (GameObject go in gosList)
        {
            go.SetActive(active);
        }
    }
    void  enableArrow()
    {

        if (PlayerPrefs.HasKey("Mode"))
        {
            mode = PlayerPrefs.GetString("Mode");
            if (!string.IsNullOrEmpty(mode))
            {

            }
            else
            {
                mode = "Earth";
            }
        }
        else
        {
            mode = "Earth";
        }
        gosEarth = GameObject.FindGameObjectsWithTag("btnEarth");
        gosSpace = GameObject.FindGameObjectsWithTag("btnSpace");
        
        if (mode.Equals("Earth"))
        {
            setActive(true,gosEarth);
            setActive(false,gosSpace);
        }
        else if (mode.Equals("Space"))
        {
            setActive(false,gosEarth);
            setActive(true,gosSpace);
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
