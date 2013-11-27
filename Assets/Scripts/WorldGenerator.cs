using UnityEngine;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour {
	
	// FIXME: Some of the following are redundant.
	/* Prefabs. */
	public GameObject basicBuilding;
	public GameObject groundTile;
	public GameObject checkpointPrefab;
	public GameObject player;
	/* Generation parameters. */
	public int tilesX = 20;
	public int tilesY = 20;
	public int tileScale = 100;
	public float rejectRate = 0.5f;
	/* Spawning parameters. */
	public float playerHeight = 100;
	public float checkpointHeight = 100;
	
	/* List of available spawnpoints. It gets filled in Awake(). */
	public readonly List<IntPair> spawnpoints = new List<IntPair>();
	
	private System.Random ranGen = new System.Random();
	
	public class IntPair {
		public readonly int x;
		public readonly int y;
		public IntPair(int x, int y) {
			this.x = x;
			this.y = y;
		}
	}
	
	public void Start() {
		GenerateMap();
		
		/* Place the player. */
		// FIXME: It would probably be a better idea to Instantiate() the player instead.
		player = GameObject.Find("Player");
		var ps = RandSpawnpoint();
		player.transform.position = GetUnityPos(ps.x, ps.y,playerHeight, true);
		
		/* Place a single checkpoint in a random location. */
		// FIXME: It would probably be a better idea to place this in some other script.
		SpawnCheckpoint(RandSpawnpoint());
	}
	
	/* Select a random spawnpoint from the field spawnpoints.
	 * May be redundant. The field spawnpoints is public.
	 */
	public IntPair RandSpawnpoint() {
		return spawnpoints[ranGen.Next(spawnpoints.Count)];
	}
	
	/* Spawn a single checkpoint in the specified tile. */
	// FIXME: Redundant. Remove this method and use SpawnObject() instead.
	public GameObject SpawnCheckpoint(IntPair tile) {
		return SpawnObject(checkpointPrefab, tile, checkpointHeight);
	}
	
	/* Place an active game object in the specified tile. */
	public GameObject SpawnObject(Object gameObject, IntPair tile, float height) {
		Vector3 pos = GetUnityPos(tile.x, tile.y, height, true);
		return Instantiate(gameObject, pos, Quaternion.identity) as GameObject;
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
	
	/* Transform tile coordinates to Unity coordinates. */
	private Vector3 GetUnityPos(int x, int y, float height = 0, bool center = false) {
		float nx = x + (center ? 0.5f : 0f);
		float ny = y + (center ? 0.5f : 0f);
		return new Vector3(nx * tileScale, height, ny * tileScale);
	}
	
}
