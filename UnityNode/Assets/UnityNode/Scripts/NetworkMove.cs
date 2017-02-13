using UnityEngine;
using System.Collections;
using SocketIO;

public class NetworkMove : MonoBehaviour {

	public SocketIOComponent socket;

	public void OnMove(Vector3 position){
		//Send position to node.
		Debug.Log("Sending position to node " + position);
		socket.Emit("move");
	}
}
