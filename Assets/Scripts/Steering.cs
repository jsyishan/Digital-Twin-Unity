using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour {

	public float weight = 1.0f;
	public virtual Vector3 Force() {
		return Vector3.zero;
	}
}
