using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public Camera leftCamera;
	public Camera topCamera;
	public Camera backCamera;
	public Camera mainCamera;

	private bool isSingleView = true;
	void Start () {

	}
	

	void Update () {
	}

	public void SwitchViews() {
		if (isSingleView) {
			mainCamera.rect = new Rect(0.5f, 0.0f, 0.5f, 0.5f);

		} else {
			mainCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
		}
		leftCamera.enabled = isSingleView;
		topCamera.enabled  = isSingleView;
		backCamera.enabled = isSingleView;
		isSingleView = !isSingleView;
	}
}
