using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	// Use this for initialization
	public CameraManager cameraManager;
	public UIManager uiManager;
	void Start () {
		if (cameraManager == null) {
			cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
		}
		if (uiManager == null) {
			uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			cameraManager.SwitchViews();
			uiManager.switchMinimap();
		}
	}
}
