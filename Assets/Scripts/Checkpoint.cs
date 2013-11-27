using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	private Camera target;
	private Game game;
	
	public void Start() {
		target = GameObject.Find("Camera").GetComponent<Camera>();
		GameObject.Find("Player").GetComponent<Player>().currentCheckpoint = this.gameObject;
		game = GameObject.Find("World").GetComponent<Game>();
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
