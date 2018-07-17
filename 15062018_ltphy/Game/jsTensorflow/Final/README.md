# Action Learning
## Files for adjustment purpose

index.html and files in style folder(footer.styl, machine.styl,...) is modified for changing layout. 

DirectionOutput.js is added as a new Output section.

OutputSection.js is modified so that there is only 1 output option. There will be no instruction video as Wizard.js is modified.  

This version is different from the orignal one (Teachable Machine)[https://teachablemachine.withgoogle.com/] (UI, no instruction video, and there is only 1 output type).

## Socket Version
There are 3 different folders in terms of 3 different socket version.<br/>
- The index.js and ws.js as server should be put at the outermost folder.
- The DirectionOutput.js is put inside src/outputs.
You may choose different sockets for different purposes. But as the goal of this project, I choose the ReconnectingWebSocket.

To use the whole folder containing all style, js, html file: 
```
app.use(express.static(__dirname+'/public'));
```
### [SocketIO](https://socket.io/) 
To prevent constant disconnect, in server script:
```
var io = require('socket.io')(http,{ pingInterval: 500});
```
### [WebSocket](https://www.npmjs.com/package/websocket)
- Check the current state of the websocket, and the message can only be sent if the socket is openned.
- If the send message is not handled appropriately, the 'Closed error' event will appear.
- Reason: the socket is already closed but the send function execute.
```
setInterval(
        () =>{
          if(ws.readyState===ws.OPEN &&mess!==premess) 
          {
            ws.send(mess, function ack(error) {
           // If error is not defined, the send has been completed, otherwise the error
          // object will indicate what failed.
            });
          }
        }, 185);
```
- The message will be sent after every 185ms.
### [ReconnectingWebSocket](https://github.com/pladaria/reconnecting-websocket)
- The server is the same as WebSocket.
- However i use ReconnectingWebSocket for the client of DirectionOutput.js.
- By using ReconnectingWebSocket, there are options that the client can try to reconnect after a certain time.
```
const ReconnectingWebSocket = require('reconnecting-websocket');
var wsURL ='ws://192.168.1.94:9000';
const options = {
	connectionTimeout: 1000,
	maxRetries: 10,
}
var ws = new ReconnectingWebSocket(wsURL,[],options);
```
