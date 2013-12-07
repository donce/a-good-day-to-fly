using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

	public Vector3 arrowOffset = new Vector3(0, 10, 40);

	private Player player;
	private FollowCamera cam;
	private Game game;
	private GameObject arrow;
	private GUIText guiSpeed;

	public void Start() {
		player = GameObject.Find("Player").GetComponent<Player>();
		cam = GameObject.Find("Camera").GetComponent<FollowCamera>();
		game = GameObject.Find("World").GetComponent<Game>();
		arrow = GameObject.Find("Arrow");
		guiSpeed = GameObject.Find("GUISpeed").GetComponent<GUIText>();
	}

	public void Update() {
		// TODO: LookAt nearest checkpoint.
		if(game.currentCheckpoint) {
			arrow.SetActive(true);
			Vector3 rotatedOffset = cam.transform.rotation * arrowOffset;
			arrow.transform.position = cam.transform.position + rotatedOffset;
			arrow.transform.LookAt(game.currentCheckpoint.transform.position);
		}
		else {
			arrow.SetActive(false);
		}

		/* The One True Unit of Speed. */
		guiSpeed.text = ((int) player.rigidbody.velocity.magnitude).ToString() + " m/s";
	}
}
