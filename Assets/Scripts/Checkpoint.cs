using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	GameObject target;
	WorldGenerator world;
	
	public void Awake() {
		target = GameObject.Find("Camera");
		world = GameObject.Find("World").GetComponent<WorldGenerator>();
		GameObject.Find("Player").GetComponent<Player>().currentCheckpoint = this.gameObject;
	}
	
	public void Update() {
		transform.LookAt(target.transform.position);
	}
	
	public void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		Debug.Log("Checkpoint!");
		// FIXME: Use SpawnObject() instead.
		world.SpawnCheckpoint(world.RandSpawnpoint());
	}
	
}
