using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateSpeed : MonoBehaviour {
	
	private bool isCalculating = false;
	public void Calculate() {
		isCalculating = true;
	}

	private void Update() {
		if (isCalculating) {
			if (Input.GetMouseButton(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 20.0f, LayerMask.GetMask("Boat"))) {
					isCalculating = false;
					Debug.Log(hit.transform.InverseTransformPoint(hit.point));
				}
			}			
		}
	}
}
