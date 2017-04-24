using UnityEngine.SceneManagement;
using UnityEngine;

public class GM : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	public void StartButton() {
		SceneManager.LoadScene("test");
	}

	public void ExitButton() {
		Application.Quit();
	}
}
