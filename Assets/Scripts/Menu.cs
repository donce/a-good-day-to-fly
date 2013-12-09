using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture2D backgruondTexture;

	void OnGUI() {
		Debug.Log("OnGUI-");
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgruondTexture);
		GUI.Box(new Rect(10, 10, 100, 90), "Game");
		//GUI.DrawTexture(GUI.Window.clientRect, backgruondTexture);
		if (GUI.Button(new Rect(10, 10, 200, 20), "Start")) {
			StartClicked();
		}
	}

	void StartClicked() {
		Debug.Log("game starts");
	}
}
