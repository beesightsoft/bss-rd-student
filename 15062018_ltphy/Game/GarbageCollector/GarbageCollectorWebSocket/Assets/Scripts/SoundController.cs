using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public GameObject sound;
    // Use this for initialization
    public GameObject mute, enable;
    void Start() {
        if (SettingStat.IsSound == true)
        {
           // Debug.Log("playsound");
            sound.GetComponent<AudioSource>().enabled = true;
            if (mute != null && enable != null)
            {
                mute.SetActive(false);
                enable.SetActive(true);
            }
        }
        else
        {
            //Debug.Log("mutesound");
            sound.GetComponent<AudioSource>().enabled = false;
            if (mute != null && enable != null)
            {
                mute.SetActive(true);
                enable.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
    public void ActivateSound()
    {
        sound.GetComponent<AudioSource>().enabled = true;
        SettingStat.IsSound = true;
    }
    public void DeactivateSound()
    {
        sound.GetComponent<AudioSource>().enabled = false;
        SettingStat.IsSound = false;
    }
}
