var io = require('socket.io')(process.env.PORT || 3000);
var shortid = require('shortid');

console.log('Server started');

var playerCount = 0;

io.on('connection', function(socket){
    var thisClientId = shortid.generate();

	console.log('Client connected, broadcasting spawn, id:' , thisClientId);

	socket.broadcast.emit('spawn');
	playerCount++;
    
    for(i=0; i<playerCount; i++){
        socket.emit('spawn');
        console.log('Sending spawn to new player');
    }
    
	socket.on('move', function(data) {
        data.id = thisClientId;
    	console.log('Client moved', JSON.stringify(data));

        socket.broadcast.emit('move', data);
	});
    
    socket.on('disconnect', function() {
        console.log('Client disconnected');
        playerCount--;
    });
})