using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


    string mode = "";
    // Use this for initialization
	void Start () {
		
	}
    void ChangeMode() {
        if (PlayerPrefs.HasKey("Mode"))
        {
            if (mode != PlayerPrefs.GetString("Mode"))
            {
                PlayerPrefs.SetString("Mode", mode);
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetString("Mode", mode);
            PlayerPrefs.Save();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void OnEarthClicked()
    {
        mode = "Earth";
    }
    public void OnSpaceClicked()
    {
        mode = "Space";
    }
    public void OnBackClicked()
    {
        ChangeMode();
        SceneManager.LoadScene("Menu");
    }
}
