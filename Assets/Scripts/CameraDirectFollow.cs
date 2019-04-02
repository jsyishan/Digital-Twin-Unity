using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirectFollow : MonoBehaviour {

	public Transform target;

	private Vector3 offset;

	private void Start() {
		offset = target.position - transform.position;
	}
	void LateUpdate () {
		transform.position = target.position - offset;
	}
}
