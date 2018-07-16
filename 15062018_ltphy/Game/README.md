# Action Learning
## About
Action Learning is an intermediary website that uses machine learning to figure out human's movement for user purpose.
Its layout was adjusted to be more convenient in term of the developer purpose.
Action Learning is attached with WebSocket to use for player movement in Garbage Collector Game.
It was made under BeesightSoft internship duration and is referenced from T[eachable Machine](https://teachablemachine.withgoogle.com/)

The experiment is built using the [deeplearn.js](https://github.com/PAIR-code/deeplearnjs) library.


### Edit server
```
GOTO:
..\jsTensorflow\src\outputs\DirectionOutput and change your websocket URL.
	EX:	var wsURL ='ws://192.168.1.2:9000';
```
#### Build project
```
yarn build
```
#### Start local server by running 

```
node index.js
```
### Access server
Go to localhost:3000 to see your complete build. 
The DirectionOutput acts as a client and send the 'order' to server.
RECOMMENDED: Each order should be trained with 10 or more samples so that the output will give out the best result. 

# GarbageCollector
### Run WebGL Game Version

In the project folder
download http-server (assume that you already have npm)
```
npm i http-server
```
### Access the game's server
```
http-server
```
Go to one of the IP listed in the console and the game should be loaded.
### How To Play Game
1) Casual mode <br/>
Use left and right arrow on keyboard to play.
2) Hardcore mode <br/>
Choose Settings and Enter the Websocket IP the same with one in the DirectionOutput.js client.   
After training completely 3 directions from jsTensorflow. You can use your movement to give order for the car movement.

## Credit
Special Thank to my supervisor [NhanCV](https://github.com/beesightsoft/bss-rd-student/commits?author=nhancv) and BEESIGHTSOFT(https://github.com/beesightsoft).



