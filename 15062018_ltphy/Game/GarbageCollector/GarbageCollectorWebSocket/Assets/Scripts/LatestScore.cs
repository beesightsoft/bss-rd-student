using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatestScore : ScoreStrategy {
    public GameObject TextGUI;
    public void setScore()
    {
        TextGUI.GetComponent<Text>().text = Scenes.getParam("score");//recieve key from CollideEvent.cs when Boom
    }
    public LatestScore(GameObject text)
    {
        TextGUI = text;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
