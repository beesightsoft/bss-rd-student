using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollideEvent : MonoBehaviour {

    // Use this for initialization
    public GameObject TextGUI;
   // TrackMovement move = new TrackMovement();
   // Spawner spawner = new Spawner();
    bool invicible = false;
    private float inviTime;
    float tmpTime = 6f;
    public GameObject anim;
    public static Score score = new Score();
    public AudioClip scoreSound;
    public AudioClip crashSound;
    int highScore;
    int scoreUP = 0;
    public GameObject mask;
   //public PlayerMovementController player;
   // public PlayerMovementController player;
    void Start () {
        inviTime = tmpTime;
        InvokeRepeating("ScoreUpdate",1.0f,1.0f);
       
    }
    void ScoreUpdate()
    {
        scoreUP += 1;
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
            //Debug.Log("got here");
            inviTime -= Time.deltaTime;
            if (inviTime <= 0)
            {
                inviTime = tmpTime;
                invicible = false;
                SettingStat.Mode.SetModeStat(); //change back to original mode after invicible time

                anim.SetActive(false);
            }
        }
        TextGUI.GetComponent<Text>().text = scoreUP.ToString();
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
            if (SettingStat.IsSound == true)
            {
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlaySoundOneTime(crashSound);
            }
            SettingStat.Mode.SetModeStat();//if it both hit the enemy and the energy it will reset to original state.
            if (!SettingStat.IsNormal)
            {
                PlayerMovementController.DoClose();
            }
            Scenes.Load("GameOver","score" , score.GetScore().ToString());
        }
        else if (collision.gameObject.tag.Equals("Garbage"))
        {
            scoreUP += 3;
            TextGUI.GetComponent<Text>().text = scoreUP.ToString();
            if (SettingStat.IsSound == true)
            {
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlaySoundOneTime(scoreSound);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Energy"))
        {

            Mode mode = new EnergyMode();//create a energy mode
            mode.SetModeStat();
            invicible = true;
            Destroy(collision.gameObject);
            anim.SetActive(true);
            
        }
    }
}
