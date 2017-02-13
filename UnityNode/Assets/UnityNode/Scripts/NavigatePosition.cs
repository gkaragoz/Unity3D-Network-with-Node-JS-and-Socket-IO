using UnityEngine;

public class NavigatePosition : MonoBehaviour {

	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	public void NavigateTo (Vector3 position) {
		agent.SetDestination(position);
	}
}
