var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http,{pingInterval:500});

app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});

var userId = 0;
io.on('connection', function(socket){
  socket.userId = userId++;
  console.log('a user connected, user id: ' + socket.userId);

  socket.on('chat', function(msg){
    console.log('message from user#' + socket.userId + ": " + msg);
    io.emit('chat', {
      id: socket.userId,
      msg: msg
    });
  });
  socket.on('disconnect',function(){
    console.log('user disconnected'); 
     io.emit('chat', "one guy is disconnected");
  });
   socket.broadcast.emit('palalal');//send a message to everyone except for a certain socket
});

http.listen(3000, function(){
  console.log('listening on *:3000');
});