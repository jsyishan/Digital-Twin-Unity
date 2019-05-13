using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateSpeed : MonoBehaviour {
	
	public Text speedText;
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
					Debug.DrawLine(ray.origin, hit.point, Color.red, 1000.0f);
					Debug.Log(hit.point);
				}
			}
		}
	}
}
