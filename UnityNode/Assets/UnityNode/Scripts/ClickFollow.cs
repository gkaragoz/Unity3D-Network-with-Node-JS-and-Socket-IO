using UnityEngine;
using System.Collections;
public class ClickFollow : MonoBehaviour, IClickable {
    void IClickable.OnClick(RaycastHit hit)
    {
		Debug.Log("Following " + hit.collider.gameObject.name);
    }
}
