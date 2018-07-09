var express = require('express');
var app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http,{ pingInterval: 500});
app.use(express.static(__dirname+'/public'));// read the whole file in public

var userId = 0;
io.on('connection', function(socket){
  socket.userId = userId++;
  console.log('a user connected: '+socket.userId);

  socket.on('chat', function(msg){
    console.log(msg);
    io.emit('chat', {

      msg: msg
    });
  });	
  socket.on('disconnect',function(){
    console.log('user disconnected'); 
     io.emit('chat', "one guy is disconnected");
  });
   //socket.broadcast.emit('palalal');//send a message to everyone except for a certain socket
});

http.listen(3000, function(){
  console.log('listening on *:3000');
});