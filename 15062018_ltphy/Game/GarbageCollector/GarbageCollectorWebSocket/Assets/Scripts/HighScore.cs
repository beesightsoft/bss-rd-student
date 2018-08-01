using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : ScoreStrategy {

    // Use this for initialization
    public GameObject TextGUI;

    public void setScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            TextGUI.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            TextGUI.GetComponent<Text>().text = "Best: " + "0";

        }
    }
    public HighScore(GameObject text)
    {
        TextGUI = text;
    }

    void Start () {
   
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
