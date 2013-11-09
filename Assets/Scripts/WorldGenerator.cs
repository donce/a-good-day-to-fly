using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	public GameObject basicBuilding;
	public Checkpoint checkpointPrefab;
	public int tilesX = 20;
	public int tilesY = 20;
	
	public const int tileWidth = 50;
	public const int tileHeight = 50;
	
	private Checkpoint lastCheckpoint = null;
	
	void Awake() {
		for (int i = 0; i < tilesX; i += 2) {
			for (int j = 0; j < tilesY; j += 2) {
				BuildBasic(i, j);
			}
		}
		AddCheckpoint(-1, 2);
		AddCheckpoint(-1, 5);
		AddCheckpoint(-1, 8);
		
	}
	
	Object BuildObject(Object gameObject, int x, int y, int height = 0, bool center = false) {
		float nx = x + (center ? 0.5f : 0f);
		float ny = y + (center ? 0.5f : 0f);
		Vector3 pos = new Vector3(nx * tileWidth, height, ny * tileHeight);
		return Instantiate(gameObject, pos, Quaternion.identity);
	}
	
	void BuildBasic(int x, int y) {
		BuildObject(basicBuilding, x, y);
	}
	
	void AddCheckpoint(int x, int y) {
		Checkpoint checkpoint = (Checkpoint)BuildObject(checkpointPrefab, x, y, 50, true);
		if (lastCheckpoint) {
			checkpoint.gameObject.SetActive(false);
			lastCheckpoint.next = checkpoint;
		}
		else
			checkpoint.gameObject.SetActive(true);
		lastCheckpoint = checkpoint;
	}
}
