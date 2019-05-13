using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSync : MonoBehaviour {

	public Transform boat;
	void Update () {
		if (boat != null) {
			this.transform.rotation = boat.rotation;
		}
	}
}
