using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {
    string mode;
    // Use this for initialization
    Color maskColor;
    public GameObject mask;
    public float transitionSpeed = 0.05f;
    bool isTransition = false;
    
    void Start() {
        if(mask!=null)
        maskColor = mask.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update() {
        if (isTransition)
        {
            maskColor.a += transitionSpeed;
            mask.GetComponent<Image>().color = maskColor;
            if (maskColor.a >= 1)
            {
                isTransition = false;
                GoToModeScene();
            }
        }
    }
    public void StartTransition()
    {
        mask.SetActive(true);
        isTransition = true;
    }
    public void GoToModeScene()
    {
        if (PlayerPrefs.HasKey("Mode"))
        {
            mode = PlayerPrefs.GetString("Mode");
            if (mode != null)
            {
                GoToScene(mode);
            }
            else
            {
                GoToScene("Earth");
            }
        }
        else
        {
            GoToScene("Earth");
        }
    }
    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
   
}
