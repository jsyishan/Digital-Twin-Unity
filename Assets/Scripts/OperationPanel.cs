using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationPanel : MonoBehaviour {
	

	public CameraManager cameraManager;
	public UIManager uiManager;

	public GameObject trail;
	public RenderTexture minimapTexture;

	private bool _track = false;

	public void SwitchView() {
		cameraManager.SwitchViews();
		uiManager.switchMinimap();
	}
	
	public void ShowTrack() {
		_track = !_track;
		trail.SetActive(_track);
	}

	public void LockCamera() {
		cameraManager.LockFreeCamera();
	}

	public void BackToMain() {
		cameraManager.SwitchViews();
		uiManager.switchMinimap();
	}

	public void SwitchMinimap() {
		if (!cameraManager.minimapCamera.targetTexture) {
			cameraManager.minimapCamera.targetTexture = minimapTexture;
		} else {
			cameraManager.minimapCamera.targetTexture = null;
		}
	}
}
