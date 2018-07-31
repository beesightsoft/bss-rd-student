var WebSocketServer = require('ws').Server,
  wss = new WebSocketServer({port: 9000})
var mess = "x";
var premess = "";
//var startTime = new Date().getTime();
function noop() {}

function heartbeat() {
  this.isAlive = true;
}
wss.on('connection', function (ws) {
  ws.isAlive = true;
  ws.on('pong', heartbeat);
  //mess = "x";
  //premess = "";
  ws.on('message', function (message) {
    console.log('received: %s', message)
    premess = mess;
    mess = message;
    //startTime = new Date().getTime();
    //console.log(ws.OPEN);
   // console.log(ws.readyState);
  	//ws.send(mess);
  })//recieve message from client

 setInterval(
      () =>{

        if(ws.readyState===ws.OPEN &&mess!==premess) 
          {
            //console.log(mess)
            //console.log(premess)
            //try{ws.send(`${mess}`);}catch(e){ }

            ws.send(mess, function ack(error) {
           // If error is not defined, the send has been completed, otherwise the error
          // object will indicate what failed.
            });
 			premess = mess
          }
           /*else if(ws.readyState===ws.OPEN &&mess===premess&& new Date().getTime()-startTime >500 ) 
          {
          	console.log(startTime)

            //console.log(mess)
            //console.log(premess)
            //try{ws.send(`${mess}`);}catch(e){ }
            ws.send(mess, function ack(error) {
           // If error is not defined, the send has been completed, otherwise the error
          // object will indicate what failed.
            });
 			premess = mess
 			startTime = 0
          }*/
        }, 
      50
      );//set ping interval for each e/*mitted message*/
  	//ws.send('${mess}')
	ws.on('close', function() {
    // close user connection
    console.log("A user disconnnected");
		mess  = "x";
		premess ="";
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
