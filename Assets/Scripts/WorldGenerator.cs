using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	public GameObject basicBuilding;
	public Checkpoint checkpointPrefab;
	public int tilesX = 20;
	public int tilesY = 20;
	
	public int checkpointsCount = 5;
	
	public const int tileWidth = 100;
	public const int tileHeight = 100;
	
	private Checkpoint lastCheckpoint = null;
	
	void Awake() {
		bool[,] a = new bool[tilesX, tilesY];
		for (int i = 0; i < tilesX; ++i)
			for (int j = 0; j < tilesY; ++j)
				a[i, j] = true;
		
		int cx = tilesX / 2;
		int cy = tilesY / 2;
		for (int i = cx-1; i <= cx+1; ++i)
			for (int j = cy-1; j < cy+1; ++j)
				a[i, j] = false;
		GameObject player = GameObject.Find("Player");
		player.transform.position = getPosition(cx, cy, 50, true);
		
		int nx, ny;
		int px = cx, py = cy;
		for (int i = 0; i < checkpointsCount; ++i) {
			nx = Random.Range(1, tilesX-1);
			ny = Random.Range(1, tilesY-1);
			while (nx != px) {
				px += nx > px ? 1 : -1;
				a[px, py] = false;
			}
			while (ny != py) {
				py += ny > py ? 1 : -1;
				a[px, py] = false;
			}
			px = nx;
			py = ny;
			AddCheckpoint(nx, ny);
		}
		
		for (int i = 0; i < tilesX; ++i)
			for (int j = 0; j < tilesY; ++j)
				if (a[i, j])
					BuildBasic(i, j);
	}
	
	Vector3 getPosition(int x, int y, int height = 0, bool center = false) {
		float nx = x + (center ? 0.5f : 0f);
		float ny = y + (center ? 0.5f : 0f);
		return new Vector3(nx * tileWidth, height, ny * tileHeight);
	}
	
	Object BuildObject(Object gameObject, int x, int y, int height = 0, bool center = false) {
		Vector3 pos = getPosition(x, y, height, center);
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
			
			checkpoint.gameObject.GetComponent<Checkpoint>().Activate();
		lastCheckpoint = checkpoint;
	}
}
