using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlatformController : MonoBehaviour {

    public GameObject normal;
    public GameObject ml;
    public GameObject inputServer;
    public GameObject IP;
    // Use this for initialization
    private String IPvalue;
	void Start () {
       
        if (SettingStat.IsNormal)
        {
            normal.SetActive(true);
            ml.SetActive(false);
            inputServer.SetActive(false);
        }
        else
        {
            normal.SetActive(false);
            ml.SetActive(true);
            inputServer.SetActive(true);
          //  Debug.Log(SettingStat.ServerURL);
            if (SettingStat.ServerURL!="localhost:9000") //if serverURL different from default
            {
                //Debug.Log(SettingStat.ServerURL);
                IP.GetComponent<InputField>().text = SettingStat.ServerURL;
                TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, false, true, true);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (SettingStat.IsNormal)
        {
            normal.SetActive(true);
            ml.SetActive(false);
            inputServer.SetActive(false);
        }
        else
        {
            normal.SetActive(false);
            ml.SetActive(true);
            inputServer.SetActive(true);
     
        }
    }
    public void OnPlatformClick(bool isNormal)
    {
        SettingStat.IsNormal = isNormal;
    }
 
    public void OnBackClick()
    {

        IPvalue = (String)IP.GetComponent<InputField>().text;//Work with Input field not text
        //Debug.Log(IPvalue);
        if (!String.IsNullOrEmpty(IPvalue)&&!IPvalue.Equals(SettingStat.ServerURL))//if the input string is not null or empty and it diffreent from old server URL, set it to global scope
        {
            SettingStat.ServerURL = IPvalue;
            //Debug.Log(SettingStat.ServerURL);
        }
        Scenes.Load("Menu");
    }
}
