using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float moveSpeed = 8f;
    // Use this for initialization
    Vector3 position;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        /*position.y +=  -moveSpeed * Time.deltaTime;
        transform.position = position;*/
        transform.Translate(new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime);
        
    }
}
