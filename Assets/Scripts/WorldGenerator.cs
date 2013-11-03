using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	public GameObject basicBuilding;

	public int tilesX = 20;
	public int tilesY = 20;
	public int tileWidth = 20;
	public int tileHeight = 20;

	void Awake() {
		for (int i = 0; i < tilesX; i += 2) {
			for (int j = 0; j < tilesY; j += 2) {
				BuildBasic(i, j);
			}
		}
	}

	void BuildBasic(int x, int y) {
		Vector3 pos = new Vector3(x * tileWidth, y * tileHeight, 0);
		Instantiate(basicBuilding, pos, Quaternion.identity);
	}
}
