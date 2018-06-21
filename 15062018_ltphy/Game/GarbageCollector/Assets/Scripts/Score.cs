using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Use this for initialization
    private int score;
  

    private void Start()
    {
           
    }
    public int GetScore()
    {
        return score;
    }

    public void SetScore(int value)
    {
        score = value;
    }

}
