using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movementData {
    public string msg;
};
public class PlayerMovementController : MonoBehaviour {
   
    public string serverURL = "ws://localhost:40510";
    private const float moveValue = 3.5f;
    private const float  maxPos = moveValue;
    // Use this for initialization
    bool currentPlatformAndroid = false;
    public bool isSocketAvailable = false;
    Vector3 position;
    protected string order = "";
    void Awake()
    {
#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif
    }
    IEnumerator Start()
    {
        position = transform.position;
        WebSocket w = new WebSocket(new Uri("ws://localhost:40510"));
        yield return StartCoroutine(w.Connect());
        w.SendString("User Unity");
        while (true)
        {
            order = w.RecvString();
            
            if (order != null)
            {
         
                Debug.Log("Received order: " + order);
            }
            if (w.error != null)
            {
                Debug.LogError("Error: " + w.error);
                break;
            }
            yield return 0;
        }
        w.Close();
  
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatformAndroid == true)
        {
            TouchMove();
        }
        else
        {
            NormalPlatform();
        }
        if (isSocketAvailable)
        {
                if (!string.IsNullOrEmpty(order))
                {
                    //Debug.Log("Received:" + order);
                    if (order.Equals("left"))
                    {

                        //Debug.Log("getit"+ order);
                        position.x -= moveValue;

                    }
                    else if (order.Equals("right"))
                    {
                        position.x += moveValue;
                    }
                    else if (order.Equals("stand"))
                    {
                        position.x += 0;
                    }
                    order = "";
                }
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
    void NormalPlatform()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position.x -= moveValue;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position.x += moveValue;
        }
    }
    void TouchMove()
    {
        if(Input.touchCount > 0) //does touch the screen
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width/2;
            Debug.Log("Left");
       
            if (touch.position.x < middle&&touch.phase ==TouchPhase.Ended) //if the user begin to touch
            {

                position.x -= moveValue;
            }
            else if (touch.position.x > middle && touch.phase == TouchPhase.Ended) //if the user begin to touch
            {
                position.x += moveValue;
            }
        }
    }

}
