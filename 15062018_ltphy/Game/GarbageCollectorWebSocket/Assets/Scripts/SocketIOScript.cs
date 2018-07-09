using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json;

public class ChatData {
	public string id;
	public string msg;
};

public class SocketIOScript : MonoBehaviour {
	public string serverURL = "http://localhost:3000";

	public InputField uiInput = null;
	public Button uiSend = null;
	public Text uiChatLog = null;

	protected Socket socket = null;
	protected List<string> chatLog = new List<string> (); 

	void Destroy() {
		DoClose ();
	}

	// Use this for initialization
	void Start () {
		DoOpen ();

		uiSend.onClick.AddListener(() => {
			SendChat(uiInput.text);
			uiInput.text = "";
			uiInput.ActivateInputField();
		});
	}
	
	// Update is called once per frame
	void Update () {
		lock (chatLog) {
			if (chatLog.Count > 0) {
				string str = uiChatLog.text;//get text from UI
				foreach (var s in chatLog) {
					str = str + "\n" + s;// add string in chat log to UI
				}
				uiChatLog.text = str; //assign it to UI
				chatLog.Clear ();// clear the UI or else it will update many times 
			}
		}
	}

	void DoOpen() {
		if (socket == null) {
			socket = IO.Socket (serverURL);
			socket.On (Socket.EVENT_CONNECT, () => {
				lock(chatLog) {
					// Access to Unity UI is not allowed in a background thread, so let's put into a shared variable
					chatLog.Add("Socket.IO connected.");
				}
			});
			socket.On ("chat", (data) => {
				string str = data.ToString();

				ChatData chat = JsonConvert.DeserializeObject<ChatData> (str);
				string strChatLog = "user#" + chat.id + "haha: " + chat.msg; //receive the signal from server which is triggered by localhost3000 

				// Access to Unity UI is not allowed in a background thread, so let's put into a shared variable
				lock(chatLog) {
					chatLog.Add(strChatLog);
				}
			});
		}
	}

	void DoClose() {
		if (socket != null) {
			socket.Disconnect ();
			socket = null;
		}
	}

	void SendChat(string str) {
		if (socket != null) {
			socket.Emit ("chat", str);//send message to server
		}
	}
}
