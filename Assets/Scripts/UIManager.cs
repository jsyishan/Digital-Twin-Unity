using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject minimap;
	public GameObject axis;
	public GameObject attitudePanel;
	public GameObject operationPanel;
	public RealtimeAttitude boat;
	public UnityStandardAssets.Cameras.FreeLookCam freeCamera;

	public GameObject backToMainButton;

	private bool isMinimapEnabled = true;
	private Text[] attitudeTexts;

	private int textsCount = 10;
	public void switchMinimap() {
		isMinimapEnabled = !isMinimapEnabled;

		minimap.SetActive(isMinimapEnabled);
		axis.SetActive(isMinimapEnabled);
		backToMainButton.SetActive(!isMinimapEnabled);

		attitudePanel.SetActive(isMinimapEnabled);
		operationPanel.SetActive(isMinimapEnabled);
	}

	private void Start() {
		attitudeTexts = new Text[textsCount];

		for (int i = 0; i < textsCount; i++) {
			attitudeTexts[i] = attitudePanel.transform.GetChild(i).GetChild(1).GetComponent<Text>();
		}
	}

	private void Update() {
		if(attitudePanel != null && boat != null) {
			attitudeTexts[0].text = System.Math.Round(boat.data.roll, 2).ToString() + "  deg";
			attitudeTexts[1].text = System.Math.Round(boat.data.pitch, 2).ToString() + "  deg";
			attitudeTexts[2].text = System.Math.Round(boat.data.yaw, 2).ToString() + "  deg";

			attitudeTexts[3].text = System.Math.Round(boat.angularSpeed.z, 2).ToString() + "  deg/s";
			attitudeTexts[4].text = System.Math.Round(boat.angularSpeed.x, 2).ToString() + "  deg/s";
			attitudeTexts[5].text = System.Math.Round(boat.angularSpeed.y, 2).ToString() + "  deg/s";

			attitudeTexts[6].text = System.Math.Round(boat.data.longitude, 2).ToString();
			attitudeTexts[7].text = System.Math.Round(boat.data.altitude, 2).ToString();
			attitudeTexts[8].text = System.Math.Round(boat.data.latitude, 2).ToString();
			attitudeTexts[9].text = System.Math.Round(boat.data.speed, 2).ToString() + "  m/s";
		}
	}
}
