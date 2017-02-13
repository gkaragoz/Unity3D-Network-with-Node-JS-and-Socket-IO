﻿using UnityEngine;
using System.Collections;

public class ScreenClicker : MonoBehaviour {

	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            Clicked();
        }
	}

    void Clicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(ray, out hit))
        {
            ClickMove clickMove = hit.collider.gameObject.GetComponent<ClickMove>();
            clickMove.OnClick(hit.point);
        }
    }
}
