using UnityEngine;

public class Checkpoint : MonoBehaviour {

	private FollowCamera target;
	private Game game;
	
	public void Start() {
		target = GameObject.Find("Camera").GetComponent<FollowCamera>();
		game = GameObject.Find("World").GetComponent<Game>();
	}
	
	public void Update() {
		transform.LookAt(target.transform.position);
	}
	
	public void OnTriggerEnter(Collider other) {
		game.PassCheckpoint(this);
		Destroy(gameObject);
	}

}
