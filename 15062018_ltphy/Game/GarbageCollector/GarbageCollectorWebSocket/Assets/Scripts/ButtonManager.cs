using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    //manage the scene Mode

    string mode = "";
  
    // Use this for initialization
    public GameObject space;
    public GameObject earth;

	void Start () {
        if (PlayerPrefs.HasKey("Mode"))
        {
            mode = PlayerPrefs.GetString("Mode");
            if (mode.Equals("Earth"))
            {
                earth.SetActive(true);
                space.SetActive(false);
            }
            else
            {
                space.SetActive(true);
                earth.SetActive(false);
            }
        }
        else
        {
            PlayerPrefs.SetString("Mode", "Earth");
            earth.SetActive(true);
            space.SetActive(false);

        }
        PlayerPrefs.Save();
    }
    void ChangeMode() {
        if (PlayerPrefs.HasKey("Mode"))
        {
            if (mode != PlayerPrefs.GetString("Mode"))
            {
                PlayerPrefs.SetString("Mode", mode);
            }
        }
        else
        {
            PlayerPrefs.SetString("Mode", mode);

        }
        PlayerPrefs.Save();
    }
    void ChangeType()
    {
        
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMapClicked(string map)
    {
        mode = map;
    }
 
    public void OnBackClicked()
    {
        ChangeMode();
        SceneManager.LoadScene(SettingStat.PrevScene);
    }
    
}
