using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

	private Player player;
	private GUIText guiSpeed;

	public void Start() {
		player = GameObject.Find("Player").GetComponent<Player>();
		guiSpeed = GameObject.Find("GUISpeed").GetComponent<GUIText>();
	}

	public void Update() {
		/* The One True Unit of Speed. */
		guiSpeed.text = ((int) player.rigidbody.velocity.magnitude).ToString() + " m/s";
	}
}
