using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json;
using Quobject.Collections.Immutable;
using Quobject.EngineIoClientDotNet.Client.Transports;

public class ChatData {
    public string msg;
};
public class PlayerMovementController : MonoBehaviour {
    Vector3 position;

    private const float moveValue = 3.5f;
    private const float  maxPos = moveValue;
    // Use this for initialization
    bool currentPlatformAndroid = false;
   // public bool isSocketAvailable = false;
    protected Socket socket = null;
    protected string order = "";
    void Awake()
    {
#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif
    }
    void Start () {
        position = transform.position;
        if (!SettingStat.IsNormal)
        {
            DoOpen();
        }

	}

    // Update is called once per frame
    void Update()
    {
        if (SettingStat.IsNormal)
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
        else
        {
            lock (order)
            {
                if (!string.IsNullOrEmpty(order))
                {
                    Debug.Log(order);
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
    void DoOpen()
    {
        if (socket == null)
        {
            string URL = "ws://" + SettingStat.ServerURL;
            Quobject.SocketIoClientDotNet.Client.IO.Options OPT = new Quobject.SocketIoClientDotNet.Client.IO.Options();
            //OPT.Reconnection = true;
            //OPT.ForceNew = false;
            //OPT.AutoConnect = true;
            //OPT.Timeout = 3000;
            OPT.Transports = ImmutableList.Create(new string[] { WebSocket.NAME, Polling.NAME });
            OPT.Reconnection = true;
          
            socket = IO.Socket(URL,OPT);
            socket.On(Socket.EVENT_CONNECT, () => {
                Debug.Log("Socket connected");
            });
            socket.On("chat", (data) => {
                string str = data.ToString();

                ChatData chat = JsonConvert.DeserializeObject<ChatData>(str);
                string strChatLog =  chat.msg; //receive the signal from server which is triggered by localhost3000 
          
                order = strChatLog;
            });
            socket.On(Socket.EVENT_DISCONNECT,()=>{
                Debug.Log("user PC disconnected");
            });
        }
    }
   public void DoClose()
    {
        if (socket != null)
        {
            socket.Disconnect();
            socket = null;
        }
    }

}
