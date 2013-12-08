using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	public float playerHeight = 100;
	public GameObject checkpointPrefab;
	public float checkpointHeightMin = 100;
	public float checkpointHeightMax = 900;
	public int checkpointCount = 3;
	public float initialTime = 60;
	public float timeBonus = 5;

	public readonly List<Checkpoint> checkpoints = new List<Checkpoint>();
	public float timeLeft { get; private set; }
	public float timeSurvived { get; private set; }

	private MapGenerator mapGen;
	private System.Random ranGen = new System.Random();

	public void Start() {
		mapGen = GameObject.Find("World").GetComponent<MapGenerator>();
		mapGen.GenerateMap();
		timeLeft = initialTime;
		timeSurvived = 0;
		StartGame();
	}

	public void FixedUpdate() {
		/* Time.deltaTime is "smart". It returns the fixed frame interval
		 * when called from FixedUpdate(). */
		var diff = Time.deltaTime;
		timeLeft -= diff;
		timeSurvived += diff;
		if(timeLeft < 0) {
			GameOver();
		}
	}

	public void PassCheckpoint(Checkpoint check) {
		checkpoints.Remove(check);
		SpawnCheckpoint();
		timeLeft += timeBonus;
	}
	
	private void StartGame() {
		/* Place the player. */
		var player = GameObject.Find("Player");
		var spawn = mapGen.RandSpawnpoint();
		player.transform.position = mapGen.GetUnityPos(spawn, playerHeight, true);
		
		/* Spawn initial checkpoints. */
		for(int i = 0; i < checkpointCount; i++) {
			SpawnCheckpoint();
		}
	}

	private void SpawnCheckpoint() {
		var spawnpoint = mapGen.RandSpawnpoint();
		var height = Mathf.Lerp(checkpointHeightMin, checkpointHeightMax, (float) ranGen.NextDouble());
		var check = mapGen.SpawnObject(checkpointPrefab, spawnpoint, height).GetComponent<Checkpoint>();
		checkpoints.Add(check);
	}

	private void GameOver() {
		// TODO: Implement. We need a GUI for this.
		Debug.Log("Game over.");
	}

}
