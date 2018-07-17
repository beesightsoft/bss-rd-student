using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEvent : MonoBehaviour {

    // Use this for initialization
    public Image background;
    public Text text;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetTransparency(float transparency)
    { //transparency is a value in the [0,1] range
        Color color = background.color;
        color.a = transparency;
        background.color = color;
    }
    public void SetColor(float a)
    {

        Color co = text.color;
        co.r = a;
        Debug.Log("call");
        //color.g = g;
        //color.b = b;
        text.color = co;
    }
    public void SetTextColor(float a)
    {
        Color co = text.color;
        co.a = a;
        Debug.Log("call");
        //color.g = g;
        //color.b = b;
        text.color = co;
    }
}
