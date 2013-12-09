using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture2D backgruondTexture;

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgruondTexture);
		int middle = Screen.width / 2;
		int vertical = Screen.height / 2;

		if (GUI.Button(new Rect(middle-100, vertical, 200, 20), "Start"))
			StartClicked();
		if (GUI.Button(new Rect(middle-100, vertical+30, 200, 20), "Quit"))
			QuitClicked();
	}

	void StartClicked() {
		Debug.Log("game starts");
	}

	void QuitClicked() {
		Debug.Log("Quit clicked");
	}
}
