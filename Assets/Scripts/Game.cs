using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public GameObject checkpointPrefab;
	public float playerHeight = 100;
	public float checkpointHeight = 100;
	
	// FIXME: Only a single checkpoint can be active at the same time.
	public GameObject currentCheckpoint;

	private MapGenerator gen;

	public void Start () {
		gen = GameObject.Find("World").GetComponent<MapGenerator>();
		gen.GenerateMap();

		/* Place the player. */
		var player = GameObject.Find("Player");
		var spawn = gen.RandSpawnpoint();
		player.transform.position = gen.GetUnityPos(spawn, playerHeight, true);

		SpawnCheckpoint();
	}

	public void SpawnCheckpoint() {
		gen.SpawnObject(checkpointPrefab, gen.RandSpawnpoint(), checkpointHeight);
	}
}
