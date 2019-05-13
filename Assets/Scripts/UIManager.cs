using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject minimap;
	public GameObject axis;
	public GameObject attitudePanel;
	public Transform attitudePanelData;
	public RealtimeAttitude boat;
	public UnityStandardAssets.Cameras.FreeLookCam freeCamera;

	private bool isMinimapEnabled = true;
	private Text[] attitudeTexts;

	private int textsCount = 7;
	public void switchMinimap() {
		isMinimapEnabled = !isMinimapEnabled;

		minimap.SetActive(isMinimapEnabled);
		axis.SetActive(isMinimapEnabled);
		attitudePanel.SetActive(isMinimapEnabled);
	}

	private void Start() {
		attitudeTexts = new Text[textsCount];

		for (int i = 0; i < textsCount; i++) {
			attitudeTexts[i] = attitudePanelData.GetChild(i).GetComponent<Text>();
		}
	}

	private void Update() {
		if(attitudePanelData != null && boat != null) {
			attitudeTexts[0].text = System.Math.Round(boat.data.roll, 2).ToString();
			attitudeTexts[1].text = System.Math.Round(boat.data.pitch, 2).ToString();
			attitudeTexts[2].text = System.Math.Round(boat.data.yaw, 2).ToString();
			attitudeTexts[3].text = System.Math.Round(boat.data.longitude, 2).ToString();
			attitudeTexts[4].text = System.Math.Round(boat.data.altitude, 2).ToString();
			attitudeTexts[5].text = System.Math.Round(boat.data.latitude, 2).ToString();
			attitudeTexts[6].text = System.Math.Round(boat.data.speed, 2).ToString();
		}
	}
}
