using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	// Use this for initialization
	public CameraManager cameraManager;
	public UIManager uiManager;

	private bool isStoppingFreeCameraRotation = false;
	private float freeCameraTurnSpeed;
	void Start () {
		if (cameraManager == null) {
			cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
		}
		if (uiManager == null) {
			uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
		}
		freeCameraTurnSpeed = uiManager.freeCamera.m_TurnSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			cameraManager.SwitchViews();
			uiManager.switchMinimap();
		}

		if (Input.GetKeyDown(KeyCode.L)) {
			isStoppingFreeCameraRotation = !isStoppingFreeCameraRotation;
			if (isStoppingFreeCameraRotation) {
				uiManager.freeCamera.m_TurnSpeed = 0.0f;
			} else {
				uiManager.freeCamera.m_TurnSpeed = freeCameraTurnSpeed;
			}
		}
	}
}
