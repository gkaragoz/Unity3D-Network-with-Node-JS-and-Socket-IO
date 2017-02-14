using System;
using UnityEngine;

public class ClickMove : MonoBehaviour, IClickable {

	public GameObject player;
	
	public void OnClick (RaycastHit hit) {
		Navigator navPos = player.GetComponent<Navigator>();
		NetworkMove netMove = player.GetComponent<NetworkMove>();
		navPos.NavigateTo(hit.point);

		netMove.OnMove(hit.point);
	}
}
