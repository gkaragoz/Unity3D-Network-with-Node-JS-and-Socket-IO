var io = require('socket.io')(process.env.PORT || 3000);

console.log('Server started');

io.on('connection', function(socket){
	console.log('Client connected');
	
	
	socket.on('move', function(data) {
		console.log('Client moved');
	});
})