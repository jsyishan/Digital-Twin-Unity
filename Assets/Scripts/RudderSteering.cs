using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderSteering : Steering {

	public int rudderPower = 0;
	public float rudderForce = 0.33f;

	void Update () {
		// Turn left or right
		if (Input.GetKeyDown(KeyCode.A)) {
			rudderPower--;	
			rudderPower = Mathf.Clamp(rudderPower, -3, 3);
			Debug.Log("Rudder Level: " + rudderPower);
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			rudderPower++;
			rudderPower = Mathf.Clamp(rudderPower, -3, 3);
			Debug.Log("Rudder Level: " + rudderPower);
		}
	}


	public override Vector3 Force() {
		Vector3 orientation = transform.right.normalized;
		// Debug.DrawRay(transform.position, orientation, Color.yellow, 0.1f);
		return orientation * rudderForce * rudderPower;
	}
}
