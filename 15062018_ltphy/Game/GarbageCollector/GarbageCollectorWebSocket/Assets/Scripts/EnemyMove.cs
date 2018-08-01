using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    // Use this for initialization
    Vector3 position;
    
	void Start () {
       // Debug.Log(ModeStat.MoveSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        /*position.y +=  -moveSpeed * Time.deltaTime;
        transform.position = position;*/
        //Debug.Log("MoveSpeed: " + ModeStat.MoveSpeed);
        transform.Translate(new Vector3(0, -1, 0) * ModeStat.MoveSpeed * Time.deltaTime);
        
    }
}
