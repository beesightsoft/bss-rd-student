using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovement : MonoBehaviour {
    public  float trackSpeed = 0.8f;
    Material ma; //fetch the material from thhe 
                 // Use this for initializatio
    float  timer;
	void Start () {
        ma = GetComponent<Renderer>().material;
	}
    public float getTrackSpeed()
    {
        return trackSpeed;
    }
    public void setTrackSpeed(float speed)
    {   
        this.trackSpeed = speed;
    }
	// Update is called once per frame
	void Update () {
        Vector2 vector = new Vector2(0, -trackSpeed*Time.time);
        ma.mainTextureOffset = vector;

	}

}
