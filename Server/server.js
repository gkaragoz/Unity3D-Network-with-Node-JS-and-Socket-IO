var io = require('socket.io')(process.env.PORT || 3000);

console.log('Server started');

var playerCount = 0;

io.on('connection', function(socket){
	console.log('Client connected, broadcasting spawn');
	
	socket.broadcast.emit('spawn');
	playerCount++;
    
    for(i=0; i<playerCount; i++){
        socket.emit('spawn');
        console.log('Sending spawn to new player');
    }
    
	socket.on('move', function(data) {
		console.log('Client moved');
	});
    
    socket.on('disconnect', function() {
        console.log('Client disconnected');
        playerCount--;
    });
})