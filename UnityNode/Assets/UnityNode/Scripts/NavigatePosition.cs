using UnityEngine;

public class NavigatePosition : MonoBehaviour {

	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () {
		agent.SetDestination(Vector3.zero);
	}
}
