using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateSpeed : MonoBehaviour {
	
	public Text speedText;
	public GameObject pointPrefab;
	private bool isCalculating = false;

	private RealtimeAttitude boatAttitude;
	private GameObject point;
	
	public void Calculate() {
		isCalculating = true;
	}

	public void Cancel() {
		isCalculating = false;
		speedText.text = "";
		Destroy(point);
		point = null;
	}

	private void Update() {
		if (isCalculating) {
			if (Input.GetMouseButton(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				// 512 means the "Boat" Layer
				if (Physics.Raycast(ray, out hit, 20.0f, 512)) {
					isCalculating = false;
					// Debug.DrawLine(ray.origin, hit.point, Color.red, 1000.0f);
					// Debug.Log(hit.point);
					// Debug.Log(hit.transform.position);
					boatAttitude = hit.transform.GetComponent<RealtimeAttitude>();
					if (point == null) {
						point = Instantiate(pointPrefab, hit.point, Quaternion.identity, hit.transform);
					} else {
						point.transform.position = hit.point;
					}
				}
			}
		}

		if (point) {
			Vector3 dir = point.transform.position - point.transform.parent.position;
			float v = boatAttitude.data.speed + (boatAttitude.angularSpeed.y * dir).magnitude;
			speedText.text = System.Math.Round(v, 2).ToString();
		}
	}
}
