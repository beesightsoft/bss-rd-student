using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    // Use this for initialization
    private ScoreStrategy strategy;
    public int option;
    public GameObject text;
	void Start () {
        setScoreStrategy(option);
        strategy.setScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void setScoreStrategy(int option)
    {
        switch (option)
        {
            case 1://normal score
                strategy = new LatestScore(text);
                break;
            case 2://high score
                strategy = new HighScore(text);
                break;
            default:
                break;
        }
    }
    void performSetScore()
    {
        strategy.setScore();
    }
}
