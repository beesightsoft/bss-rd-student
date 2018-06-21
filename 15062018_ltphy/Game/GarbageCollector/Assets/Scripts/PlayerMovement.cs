using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Vector3 position;
    private const float moveValue = 3.5f;
    private const float  maxPos = moveValue;
    GameObject effect;
    // Use this for initialization
    bool currentPlatformAndroid = false;
    void Awake()
    {
        
    }
    void Start () {

        position = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position.x -= moveValue;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position.x += moveValue;       
        }
  
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        transform.position = position;
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("CarEnemy"))
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }*/
}
