using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationPanel : MonoBehaviour {
	

	public CameraManager cameraManager;
	public UIManager uiManager;


	private bool _track = false;

	public void SwitchView() {
		cameraManager.SwitchViews();
		uiManager.switchMinimap();
	}
	
	public void ShowTrack() {

	}

	public void LockCamera() {
		cameraManager.LockFreeCamera();
	}

	public void BackToMain() {
		cameraManager.SwitchViews();
		uiManager.switchMinimap();
	}
}
