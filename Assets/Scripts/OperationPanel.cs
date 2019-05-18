using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OperationPanel : MonoBehaviour {
	

	public CameraManager cameraManager;
	public UIManager uiManager;

	public GameObject trail;
	public RenderTexture minimapTexture;
	public RenderTexture freeCameraTexture;
	public RawImage minimapImage;

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
			cameraManager.mainCamera.targetTexture = null;
			minimapImage.texture = minimapTexture;
		} else {
			cameraManager.mainCamera.targetTexture = freeCameraTexture;
			cameraManager.minimapCamera.targetTexture = null;
			minimapImage.texture = freeCameraTexture;
		}
	}
}
