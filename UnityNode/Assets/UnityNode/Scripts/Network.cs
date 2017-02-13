using UnityEngine;
using System.Collections;
using SocketIO;

public class Network : MonoBehaviour {

    static SocketIOComponent socket;

	void Start () {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
	}

    void OnConnected(SocketIOEvent e)
    {
        Debug.Log("Connected");
        socket.Emit("move");
    }
}
