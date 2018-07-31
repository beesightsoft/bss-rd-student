var express = require('express');
var ws = require('./ws')
var app = express();

//var http = require('http').Server(app);
//var io = require('socket.io')(http,{ pingInterval: 500});
app.use(express.static(__dirname+'/public'));// read the whole file in public


app.listen(3000, function(){
  console.log('listening on *:3000');
});