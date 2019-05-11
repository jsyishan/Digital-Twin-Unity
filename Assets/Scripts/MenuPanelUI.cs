using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPanelUI : MonoBehaviour {

	public GameObject helpPanel;
	public void Launch() {
		SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
	}

	public void Exit() {
		Application.Quit();
	}

	public void Help() {
		helpPanel.SetActive(true);
	}

	public void Return() {
		helpPanel.SetActive(false);
	}
}
