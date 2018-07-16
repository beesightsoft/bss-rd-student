# Action Learning
## Files for adjustment purpose

index.html and files in style folder(footer.styl, machine.styl,...) is modified for changing layout. 

DirectionOutput.js is added as a new Output section.

OutputSection.js is modified so that there is only 1 output option. There will be no instruction video as Wizard.js is modified.  

This version is different from the orignal one (Teachable Machine) (UI, no instruction video, and there is only 1 output type).

## Socket Version
There are 3 different folders in terms of 3 different socket version.
The index.js and ws.js as server should be put at the outermost folder.
The DirectionOutput.js is put inside src/outputs.
You may choose different sockets for different purposes. But as the goal of this project,
I choose the third option.

### [SocketIO](https://socket.io/) 
### [WebSocket](https://www.npmjs.com/package/websocket)
### [ReconnectingWebSocket](https://github.com/pladaria/reconnecting-websocket)
The server is the same as WebSocket.
However i use ReconnectingWebSocket for the client of DirectionOutput.js <br/>
By using ReconnectingWebSocket, there are options that the client can try to reconnect after a certain time.

