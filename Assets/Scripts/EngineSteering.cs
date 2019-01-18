using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSteering : Steering {

	public int enginePower = 0;
	public float engineForce = 0.5f; 

	void Update () {
		// Upward and Downward
		if (Input.GetKeyDown(KeyCode.W)) {
			enginePower++;
			enginePower = Mathf.Clamp(enginePower, -1, 4);
			Debug.Log("Engine Level: " + enginePower);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			enginePower--;
			enginePower = Mathf.Clamp(enginePower, -1, 4);
			Debug.Log("Engine Level: " + enginePower);
		}
	}

	public override Vector3 Force() {
		Vector3 orientation = transform.forward.normalized;
		var v = orientation * engineForce * enginePower;
		// Debug.Log(orientation + "  ---  " + v);
		// Debug.DrawRay(transform.position, v, Color.green, 0.1f);
		// Debug.DrawRay(transform.position, orientation, Color.blue, 0.1f);
		return v;
	}
}
