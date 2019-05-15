using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public Camera leftCamera;
	public Camera topCamera;
	public Camera backCamera;
	public Camera mainCamera;
	public Camera minimapCamera;
	public UIManager uiManager;

	private bool isSingleView = true;
	private bool isStoppingFreeCameraRotation = false;
	private float freeCameraTurnSpeed;

	private void Start() {
		freeCameraTurnSpeed = uiManager.freeCamera.m_TurnSpeed;
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

	public void LockFreeCamera() {
			isStoppingFreeCameraRotation = !isStoppingFreeCameraRotation;
			if (isStoppingFreeCameraRotation) {
				uiManager.freeCamera.m_TurnSpeed = 0.0f;
			} else {
				uiManager.freeCamera.m_TurnSpeed = freeCameraTurnSpeed;
			}
	}
}
