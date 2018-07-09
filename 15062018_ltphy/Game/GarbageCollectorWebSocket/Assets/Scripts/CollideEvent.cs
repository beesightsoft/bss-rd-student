using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollideEvent : MonoBehaviour {

    // Use this for initialization
    public GameObject TextGUI;
    TrackMovement move = new TrackMovement();
    Spawner spawner = new Spawner();
    bool invicible = false;
    public float inviTime;
    float tmpTime = 6f;
    public GameObject anim;
    public static Score score = new Score();
    public AudioClip scoreSound;
    public AudioClip crashSound;
    int highScore;
    public GameObject mask;
 
    void Start () {
        inviTime = tmpTime;

       
    }
    void GameOver()
    {
    
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score.GetScore() > PlayerPrefs.GetInt("HighScore"))
            {
                highScore = score.GetScore();
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            Debug.Log(score.GetScore());
            highScore = score.GetScore();
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

    }
	// Update is called once per frame
	void Update () {
		if(invicible == true)
        {
            // Debug.Log("got here");
            inviTime -= Time.deltaTime;
            if (inviTime <= 0)
            {
                inviTime = tmpTime;
                invicible = false;
                move.setTrackSpeed(0.5f);
                spawner.setTimer(1.0f);
                anim.SetActive(false);
            }
        }
       
    }
    public void StartTransition()
    {

        mask.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invicible == true && collision.gameObject.tag.Equals("CarEnemy"))
        {
 
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("CarEnemy"))
        {
            StartTransition();
            score.SetScore(int.Parse(TextGUI.GetComponent<Text>().text));
            GameOver();
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlaySoundOneTime(crashSound);
            Scenes.Load("GameOver","score" , score.GetScore().ToString());
        }
        else if (collision.gameObject.tag.Equals("Garbage"))
        {
            int t = int.Parse(TextGUI.GetComponent<Text>().text);
            t++;
            TextGUI.GetComponent<Text>().text = t.ToString();
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlaySoundOneTime(scoreSound);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Energy"))
        {
            move.setTrackSpeed(1.0f);
            spawner.setTimer(0.5f);
            invicible = true;
            Destroy(collision.gameObject);
            anim.SetActive(true);
            
        }
    }
}
