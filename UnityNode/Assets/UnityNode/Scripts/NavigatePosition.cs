using UnityEngine;

public class NavigatePosition : MonoBehaviour {

	NavMeshAgent agent;

	void Awake () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	public void NavigateTo (Vector3 position) {
		agent.SetDestination(position);
	}

	void Update (){
		GetComponent<Animator>().SetFloat("Distance", agent.remainingDistance);
	}
}
