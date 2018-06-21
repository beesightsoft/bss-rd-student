using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("CarEnemy")||collision.gameObject.tag.Equals("Garbage")||collision.gameObject.tag.Equals("Energy"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            //Debug.Log("get");
        }
    }
}
