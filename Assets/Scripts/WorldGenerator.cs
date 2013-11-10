using UnityEngine;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour {
	
	/* Prefabs. */
	public GameObject basicBuilding;
	public GameObject groundTile;
	public GameObject checkpointPrefab;
	public GameObject player;
	/* Generation parameters. */
	public int tilesX = 20;
	public int tilesY = 20;
	public int tileScale = 100;
	public float rejectRate = 0.3f;
	/* Spawning parameters. */
	public float playerHeight = 100;
	public float checkpointHeight = 100;
	
	private System.Random ranGen = new System.Random();
	private readonly List<IntPair> spawnpoints = new List<IntPair>();
	
	public class IntPair {
		public readonly int x;
		public readonly int y;
		public IntPair(int x, int y) {
			this.x = x;
			this.y = y;
		}
	}
	
	public void Awake() {
		GenerateMap();
		
		/* Place the player. */
		// FIXME: Might be a better idea to Instantiate the player instead.
		player = GameObject.Find("Player");
		var ps = RandSpawnpoint();
		player.transform.position = GetUnityPos(ps.x, ps.y,playerHeight, true);
		
		SpawnCheckpoint();
	}
	
	/* Fill the map with buildings and ground tiles. */
	private void GenerateMap() {
		var tileOpen = GenerateOpen();
		
		for(int x = 0; x < tilesX; x++) {
			for(int y = 0; y < tilesY; y++) {
				if(tileOpen[x, y]) {
					PlaceTile(groundTile, x, y);
					spawnpoints.Add(new IntPair(x, y));
				}
				else {
					PlaceTile(basicBuilding, x, y);
				}
			}
		}
	}
	
	/* Generate the openness grid. */
	private bool[,] GenerateOpen() {
		var open = new bool[tilesX, tilesY];
		
		/* Iterate through all tiles. */
		for(int x = 0; x < tilesX; x++) {
			for(int y = 0; y < tilesY; y++) {
				if(!(x % 2 == 0 && y % 2 == 0)) {
					open[x, y] = true;
				}
				else {
					if(ranGen.NextDouble() < rejectRate) {
						open[x, y] = true;
					}
				}
			}
		}
		
		return open;
	}
	
	/* Place a tile prefab in the specified tile. */
	private void PlaceTile(Object gameObject, int x, int y) {
		Vector3 pos = GetUnityPos(x, y);
		var instance = Instantiate(gameObject, pos, Quaternion.identity) as GameObject;
		instance.transform.localScale = new Vector3(tileScale, tileScale, tileScale);
	}
	
	/* Place an active game object in the specified tile. */
	private GameObject PlaceActive(Object gameObject, int x, int y, float height) {
		Vector3 pos = GetUnityPos(x, y, height, true);
		var instance = Instantiate(gameObject, pos, Quaternion.identity) as GameObject;
		return instance;
	}
	
	/* Transform tile coordinates to Unity coordinates. */
	private Vector3 GetUnityPos(int x, int y, float height = 0, bool center = false) {
		float nx = x + (center ? 0.5f : 0f);
		float ny = y + (center ? 0.5f : 0f);
		return new Vector3(nx * tileScale, height, ny * tileScale);
	}
	
	/* Select a random spawnpoint from the field spawnpoints. */
	private IntPair RandSpawnpoint() {
		return spawnpoints[ranGen.Next(spawnpoints.Count)];
	}
	
	/* Spawn a single checkpoint in a random location. */
	public void SpawnCheckpoint() {
		var cs = RandSpawnpoint();
		var checkPoint = PlaceActive(checkpointPrefab, cs.x, cs.y, checkpointHeight);
		if (player)
			player.gameObject.GetComponent<Player>().currentCheckpoint = checkPoint;
	}
	
}
