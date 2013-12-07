using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	private Camera target;
	private Game game;
	
	public void Start() {
		target = GameObject.Find("Camera").GetComponent<Camera>();
		game = GameObject.Find("World").GetComponent<Game>();
		game.currentCheckpoint = this.gameObject;
	}
	
	public void Update() {
		transform.LookAt(target.transform.position);
	}
	
	public void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		Debug.Log("Checkpoint!");
		game.SpawnCheckpoint();
	}

}
