using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour {

    // Use this for initialization
    public GameObject btnNormal;
    public GameObject btnHard;

    void Start() {
        if (SettingStat.Mode != null)
        {
            if (SettingStat.Mode.GetType() == typeof(Normal))
            {
                btnNormal.GetComponent<Image>().color = new Color(0, 0.055f, 0.16f, 100);
                btnHard.GetComponent<Image>().color = new Color(0, 0.14f, .4f, 100);
            }
            else
            {
                btnNormal.GetComponent<Image>().color = new Color(0, 0.14f, .4f, 100);
                btnHard.GetComponent<Image>().color = new Color(0, 0.055f, 0.16f, 100);
            }
        }
        else
        {
            btnNormal.GetComponent<Image>().color = new Color(0, 0.055f, 0.16f, 100);
            btnHard.GetComponent<Image>().color = new Color(0, 0.055f, 0.16f, 100);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void ClickButton(GameObject go)
    {
       go.GetComponent<Image>().color = new Color(0,0.055f,0.16f,100);
      
    }
    public void UnclickButton(GameObject go)
    {
        go.GetComponent<Image>().color = new Color(0,0.14f,.4f, 100);
    }
}
