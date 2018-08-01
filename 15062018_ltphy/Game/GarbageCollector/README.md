# GarbageCollector
## About Game

### Add mode
1) To add more modes for example easy mode
- Create an Easy class extends Mode.
- The SetModeState() should be overridden.
- In which, The MoveSpeed (speed of enemy), TrackSpeed (speed of track), DelayTime (time delay to spawn enemy) should be adjusted.
- The SettingStat.cs file is to store all the global variables which include, MoveSpeed, TrackSpeed, and DelayTime.

2) To add more maps <br/>
- You must edit 2 files ButtonManager.cs and ArrowController.cs
- In file ButtonManager.cs, you may create a list of map gameobjects in .cs file and assign a new gameobject map from unity.<br/>
- In ArrowController.cs, This script is used to manage the UI button of the main screen. Add new list of gameobject UI, for example gosSea. You may create a tag 'btnSea' in Unity so that the script can find the game object with tag 'btnSea' to handle the UI.

3) Platform <br/>
- There are 2 kind of platforms in this project. 
- Casual includes 'Android' or 'PC' controller. 
- HardCore uses socket to get order from the ActionLearning jsTensorflow project.
- All the movements of player of different plaforms are implemented under the same script PlayerMovementController.cs

Direct access in the same script with different platforms without creating any object for each platform may result in better performance.

4) To add more score type <br/>
- Create a 'GarbageScore' class extends ScoreStrategy.
- Create an overriden SetScore() method and the constructor with a gameobject Text as an argument.
- Edit ScoreController.cs to control the strategy used for different scores.
- Each TextUI in Unity will contain the script ScoreController.cs which contains different option.

If you want to separate the movement score and garbage score and use garbage score for different purpose, you may try as above.<br/>


## About Socket Version for Unity
There are 3 folders of different Socket Version.<br/>
You may try to use each of them by replacing the PlayerMovementController.cs in ../Assets/Scripts and Lib/Plugins folder in ../Assets.
Remember to assign the PlayerMovementController.cs script to Truck and Rocket Object.<br/>
The Client Unity will stop whenever the player hit an enemy car.
### [SocketIO](https://github.com/floatinghotpot/socket.io-unity)
- Support: PC
- Not-Support: WebGL

You can download socket-io from the above link or use from my project. SocketIO supports PC. However, the connection only works on local devices.<br/>

If you just want to have a test of how socketio open connection and receive data on local server. Then SocketIO is a good option. 


### [WebSocket](https://assetstore.unity.com/packages/essentials/tutorial-projects/simple-web-sockets-for-unity-webgl-38367)
- Support: WebGL + PC (different IP clients)

WebSocket is a project provided by UNITY TECHNOLOGIES. This WebSocket for WebGL works purely in term of normal communication
between clients.

You can use the orignal version from the project folder or import it via Unity asset store.<br/>
If you import via Unity asset store, remember to add the following code in WebSocket.jslib at line 32.
```
else if(typeof e.data === "string") {
            var reader = new FileReader();
            reader.addEventListener("loadend", function() {
                var array = new Uint8Array(reader.result);
                socket.messages.push(array);
            });
            var blob = new Blob([e.data]);
            reader.readAsArrayBuffer(blob);
        }
```

### [WebSocketSharp](https://github.com/sta/websocket-sharp)
- Support: PC (different IP clients)
- Not-Support: WebGL

You can use the websocket-sharp.dll in my project folder which was built from the original WebSocketSharp or self-download and built
the WebSocketSharp project.

NOTE: 
- Only WebGL and PC have already been tested. Android has not been tested yet.
- Sometimes After the modification of folders, the build folder does not work, try to reimport and build again.      
