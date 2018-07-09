var WebSocketServer = require('ws').Server,
  wss = new WebSocketServer({port: 40510})
var mess = "";
wss.on('connection', function (ws) {
  ws.on('message', function (message) {
    console.log('received: %s', message)
    mess = message;
  if((mess ==="left")||(mess==="right")||(mess==="stand"))
	{
		console.log('send: %s ',mess)
  	
		//ws.send(`${mess}`)
	}
  })//recieve message from client


   	setInterval(
    	() => ws.send(`${mess}`),
    	1000
  		)
	
})