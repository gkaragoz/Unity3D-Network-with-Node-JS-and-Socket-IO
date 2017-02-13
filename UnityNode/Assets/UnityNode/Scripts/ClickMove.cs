using UnityEngine;

public class ClickMove : MonoBehaviour {

	public GameObject player;
	
	public void OnClick (Vector3 position) {
		NavigatePosition navPos = player.GetComponent<NavigatePosition>();
		navPos.NavigateTo(position);
	}
}
