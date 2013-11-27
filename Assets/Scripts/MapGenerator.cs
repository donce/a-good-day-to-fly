using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour {

	/* Prefabs. */
	public List<GameObject> buildings;
	public GameObject groundTile;
	/* Generation parameters. */
	public int tilesX = 40;
	public int tilesY = 40;
	public int tileScale = 100;
	public float rejectRate = 0.4f;
	public float colorVariation = 0.6f;
	
	/* List of available spawnpoints. It gets filled in GenerateMap(). */
	public readonly List<Tile> spawnpoints = new List<Tile>();
	
	private System.Random ranGen = new System.Random();

	public class Tile {
		public readonly int x;
		public readonly int y;
		public Tile(int x, int y) {
			this.x = x;
			this.y = y;
		}
	}
	
	/* Fill the map with buildings and ground tiles. */
	public void GenerateMap() {
		var tileOpen = GenerateOpen();
		
		for(int x = 0; x < tilesX; x++) {
			for(int y = 0; y < tilesY; y++) {
				var tile = new Tile(x, y);
				PlaceTile(groundTile, tile);
				if(tileOpen[x, y]) {
					spawnpoints.Add(tile);
				}
				else {
					PlaceBuilding(tile);
				}
			}
		}
	}

	/* Select a random spawnpoint from the field spawnpoints.
	 * May be redundant. The field spawnpoints is public.
	 */
	public Tile RandSpawnpoint() {
		return spawnpoints[ranGen.Next(spawnpoints.Count)];
	}

	/* Place an active game object in the specified tile. */
	public GameObject SpawnObject(Object gameObject, Tile tile, float height) {
		Vector3 pos = GetUnityPos(tile, height, true);
		return Instantiate(gameObject, pos, Quaternion.identity) as GameObject;
	}
	
	/* Transform tile coordinates to Unity coordinates. */
	public Vector3 GetUnityPos(Tile tile, float height = 0, bool center = false) {
		float nx = tile.x + (center ? 0.5f : 0f);
		float ny = tile.y + (center ? 0.5f : 0f);
		return new Vector3(nx * tileScale, height, ny * tileScale);
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

	/* Place a building in the specified tile. */
	private void PlaceBuilding(Tile tile) {
		var building = buildings[ranGen.Next(buildings.Count)];
		var instanceRenderer = PlaceTile(building, tile).GetComponentInChildren<Renderer>();
		instanceRenderer.material.color = RandomColor();
	}

	/* Place a tile prefab in the specified tile. */
	private GameObject PlaceTile(Object gameObject, Tile tile) {
		var pos = GetUnityPos(tile);
		var instance = Instantiate(gameObject, pos, Quaternion.identity) as GameObject;
		instance.transform.localScale = new Vector3(tileScale, tileScale, tileScale);
		return instance;
	}

	private Color RandomColor() {
		var r = (float) ranGen.NextDouble() * colorVariation + (1 - colorVariation);
		var g = (float) ranGen.NextDouble() * colorVariation + (1 - colorVariation);
		var b = (float) ranGen.NextDouble() * colorVariation + (1 - colorVariation);
		var mean = (r + g + b) / 3;
		r = Mathf.Lerp(r, mean, colorVariation);
		g = Mathf.Lerp(r, mean, colorVariation);
		b = Mathf.Lerp(r, mean, colorVariation);
		return new Color(r, g, b);
	}

}
