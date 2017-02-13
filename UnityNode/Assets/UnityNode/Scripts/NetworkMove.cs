using UnityEngine;
using System.Collections;
using SocketIO;

public class NetworkMove : MonoBehaviour {

	public SocketIOComponent socket;

	public void OnMove(Vector3 position){
		//Send position to node.
		Debug.Log("Sending position to node " + VectorToJson(position));
		socket.Emit("move", new JSONObject(VectorToJson(position)));
	}

	string VectorToJson(Vector3 vector){
		return string.Format(@"{{""x"":""{0}"", ""y"":""{1}""}}", vector.x, vector.z);
	}
}
