var io = require('socket.io')(process.env.PORT || 3000);
var shortid = require('shortid');

console.log('Server started');

var players = [];

io.on('connection', function(socket){
    var thisClientId = shortid.generate();

    players.push(thisClientId);

	console.log('Client connected, broadcasting spawn, id:' , thisClientId);

	socket.broadcast.emit('spawn', {id: thisClientId});
    socket.broadcast.emit('requestPosition');

    players.forEach(function(playerId){
        if(playerId == thisClientId){
            return;
        }
        
        socket.emit('spawn', {id: playerId});
        console.log('Sending spawn to new player for id: ', playerId);
    });
    
	socket.on('move', function(data) {
        data.id = thisClientId;
    	console.log('Client moved', JSON.stringify(data));

        socket.broadcast.emit('move', data);
	});

    socket.on('updatePosition', function(data){
        console.log("Update position: ", data);

        data.id = thisClientId;

        socket.broadcast.emit('updatePosition', data);
    });
    
    socket.on('disconnect', function() {
        console.log('Client disconnected');

        players.splice(players.indexOf(thisClientId), 1);

        socket.broadcast.emit('disconnected', {id: thisClientId});
    });
})