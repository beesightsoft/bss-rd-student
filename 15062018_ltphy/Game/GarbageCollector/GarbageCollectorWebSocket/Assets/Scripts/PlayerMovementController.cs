using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerMovementController : MonoBehaviour
{

    private const float moveValue = 3.5f;
    private const float maxPos = moveValue;
    // Use this for initialization
    bool currentPlatformAndroid = false;
    Vector3 position;
    protected string order = "";
    public static WebSocket w = null;//for the collide event to acess when it hit enemy
    void Awake()
    {
#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif
    }
    public static void DoClose()
    {
        if (w != null)
        {
            w.Close();
        }
    }
    IEnumerator Start()
    {
        position = transform.position;
        if (!SettingStat.IsNormal)
        {
            //Debug.Log(SettingStat.ServerURL);
            String URL = "ws://" + SettingStat.ServerURL;
            w = new WebSocket(new Uri(URL));
            yield return StartCoroutine(w.Connect());
            w.SendString("User Unity");
      
            while (true)
            {
                //Debug.Log("got here");
                order = w.RecvString();
                //Debug.Log(order);
                if (order != null)
                {

                   // Debug.Log("Received order: " + order);
                }
                if (w.error != null)
                {
                    // Debug.LogError("Error: " + w.error);
                    break;
                }   
                
                yield return 0;
            }
    
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (SettingStat.IsNormal) //normal flatform input
        {
            if (currentPlatformAndroid == true)
            {
                TouchMove();
            }
            else
            {
                NormalPlatform();
            }
        }
        else //machine learning flatform input
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
        if (Input.touchCount > 0) //does touch the screen
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            Debug.Log("Left");

            if (touch.position.x < middle && touch.phase == TouchPhase.Ended) //if the user begin to touch
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
