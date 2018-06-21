using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour {

    // Use this for initialization
    public MovieTexture movie;
	void Start () {
        Renderer r = GetComponent<Renderer>();
        movie = (MovieTexture)r.material.mainTexture;

        if (movie.isPlaying)
        {
            movie.Pause();
        }
        else
        {
            movie.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
