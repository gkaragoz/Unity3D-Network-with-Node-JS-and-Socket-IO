using UnityEngine;

public class ClickMove : MonoBehaviour {

	public GameObject player;
	
	public void OnClick (Vector3 position) {
		NavigatePosition navPos = player.GetComponent<NavigatePosition>();
		NetworkMove netMove = player.GetComponent<NetworkMove>();
		navPos.NavigateTo(position);

		netMove.OnMove(position);
	}
}
