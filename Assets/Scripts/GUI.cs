using UnityEngine;

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
		if(game.checkpoints.Count > 0) {
			arrow.SetActive(true);

			Vector3 rotatedOffset = cam.transform.rotation * arrowOffset;
			arrow.transform.position = cam.transform.position + rotatedOffset;

			var nearest = game.checkpoints[0];
			foreach(var check in game.checkpoints) {
				if((check.transform.position - player.transform.position).magnitude <
				   (nearest.transform.position - player.transform.position).magnitude) {
					nearest = check;
				}
			}
			arrow.transform.LookAt(nearest.transform.position);
		}
		else {
			arrow.SetActive(false);
		}

		/* The One True Unit of Speed. */
		guiSpeed.text = ((int) player.rigidbody.velocity.magnitude).ToString() + " m/s";
	}
}
