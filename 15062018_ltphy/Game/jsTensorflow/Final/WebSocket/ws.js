var WebSocketServer = require('ws').Server,
  wss = new WebSocketServer({port: 9000})
var mess = "";
var premess = "";
function noop() {}

function heartbeat() {
  this.isAlive = true;
}
wss.on('connection', function (ws) {
  ws.isAlive = true;
  ws.on('pong', heartbeat);
  ws.on('message', function (message) {
    console.log('received: %s', message)
    premess = mess;
    mess = message;
    //console.log(ws.OPEN);
   // console.log(ws.readyState);
  	//ws.send(mess);
  })//recieve message from client

 setInterval(
      () =>{

        if(ws.readyState===ws.OPEN &&mess!==premess) 
          {
            
            //try{ws.send(`${mess}`);}catch(e){ }
            ws.send(mess, function ack(error) {
           // If error is not defined, the send has been completed, otherwise the error
          // object will indicate what failed.
            });
 
          }
        }, 
      185
      );//set ping interval for each e/*mitted message*/
  	//ws.send('${mess}')
	ws.on('close', function() {
    // close user connection
    console.log("A user disconnnected");

  });
	ws.on('error',function(){
		console.log("something");
	});

})


const interval = setInterval(function ping() {
  wss.clients.forEach(function each(ws) {
    if (ws.isAlive === false) return ws.terminate();

    ws.isAlive = false;
    ws.ping(noop);
  });
}, 500);
