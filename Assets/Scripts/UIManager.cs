using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject minimap;
	public GameObject attitudePanel;
	public Transform attitudePanelData;
	public Transform boat;

	private bool isMinimapEnabled = true;
	private Text[] attitudeTexts;

	public void switchMinimap() {
		isMinimapEnabled = !isMinimapEnabled;
		minimap.SetActive(isMinimapEnabled);
		attitudePanel.SetActive(isMinimapEnabled);
	}

	private void Start() {
		attitudeTexts = new Text[6];

		for (int i = 0;i < 6; i++) {
			attitudeTexts[i] = attitudePanelData.GetChild(i).GetComponent<Text>();
		}
	}

	private void Update() {
		if(attitudePanelData != null && boat != null) {
			attitudeTexts[0].text = boat.eulerAngles.z.ToString();
			attitudeTexts[1].text = boat.eulerAngles.y.ToString();
			attitudeTexts[2].text = boat.eulerAngles.x.ToString();
			attitudeTexts[3].text = boat.position.x.ToString();
			attitudeTexts[4].text = boat.position.y.ToString();
			attitudeTexts[5].text = boat.position.z.ToString();
		}
	}
}
