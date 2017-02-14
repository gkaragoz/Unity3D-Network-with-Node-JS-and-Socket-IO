using UnityEngine;
using SocketIO;
using System.Collections.Generic;
using System;

public class Network : MonoBehaviour {

    static SocketIOComponent socket;

    public GameObject playerPrefab;

    public GameObject myPlayer;

    Dictionary<string, GameObject> players;

	void Start () {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn", OnSpawned);
        socket.On("move", OnMove);
        socket.On("disconnected", OnDisconnected);
        socket.On("requestPosition", OnRequestPosition);
        socket.On("updatePosition", OnUpdatePosition);

        players = new Dictionary<string, GameObject>();
	}

    void OnConnected(SocketIOEvent e)
    {
        Debug.Log("Connected");
    }

    void OnSpawned(SocketIOEvent e)
    {
        Debug.Log("Player spawned" + e.data);
        GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        if (e.data["x"]){
            Vector3 movePosition = new Vector3(GetFloatFromJson(e.data, "x"), 0, GetFloatFromJson(e.data, "y"));

            Navigator navigatePos = player.GetComponent<Navigator>();

            navigatePos.NavigateTo(movePosition);
        }

        players.Add(e.data["id"].ToString(), player);
        Debug.Log("Player Count: " + players.Count);
    }
    private void OnMove(SocketIOEvent e)
    {
        Debug.Log("Player is moving " + e.data);

        Vector3 position = new Vector3(GetFloatFromJson(e.data, "x"), 0, GetFloatFromJson(e.data, "y"));

        var player = players[e.data["id"].ToString()];

        Navigator navigatePos = player.GetComponent<Navigator>();

        navigatePos.NavigateTo(position);
    }

    private void OnRequestPosition(SocketIOEvent e)
    {
        Debug.Log("Server is requesting position");

        socket.Emit("updatePosition", new JSONObject(VectorToJson(myPlayer.transform.position)));
    }

    private void OnUpdatePosition(SocketIOEvent e)
    {
        Debug.Log("Updating position: "+ e.data);

        Vector3 position = new Vector3(GetFloatFromJson(e.data, "x"), 0, GetFloatFromJson(e.data, "y"));

        var player = players[e.data["id"].ToString()];

        player.transform.position = position;
    }

    private void OnDisconnected(SocketIOEvent e)
    {
        Debug.Log("Client disconnected: " + e.data);

        string id = e.data["id"].ToString();

        var player = players[id];
        Destroy(player);
        players.Remove(id);
    }

    float GetFloatFromJson(JSONObject data, string key)
    {
        return float.Parse(data[key].ToString().Replace("\"", ""));
    }

	public static string VectorToJson(Vector3 vector){
		return string.Format(@"{{""x"":""{0}"", ""y"":""{1}""}}", vector.x, vector.z);
	}
}