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

    //ws.send(mess);
  })//recieve message from client

  if(this.readyState!==ws.CLOSED&& mess!== premess)
  {	
   setInterval(
    	() => ws.send(`${mess}`),
    	350
  		)
  }//set ping   interval for each emitted message*/
  	//ws.send('${mess}')
	ws.on('close', function() {
    // close user connection
    console.log("A user disconnnected");

  });
	ws.on('error',function(){
		console.log(' state: '+ws.readyState);
	});

})


const interval = setInterval(function ping() {
  wss.clients.forEach(function each(ws) {
    if (ws.isAlive === false) return ws.terminate();

    ws.isAlive = false;
    ws.ping(noop);
  });
}, 500);
