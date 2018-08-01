using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovement : MonoBehaviour {
  
    Material ma; //fetch the material from thhe 
                 // Use this for initializatio
    float  timer;
	void Start () {
        ma = GetComponent<Renderer>().material;
	}
 
	// Update is called once per frame
	void Update () {
        Vector2 vector = new Vector2(0, -ModeStat.TrackSpeed *Time.time);
       // Debug.Log(-ModeStat.TrackSpeed * Time.time);
        ma.mainTextureOffset = vector;

	}

}
