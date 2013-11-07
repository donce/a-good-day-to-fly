using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	public GameObject basicBuilding;
	public int tilesX = 20;
	public int tilesY = 20;

	public const int tileWidth = 50;
	public const int tileHeight = 50;

	void Awake() {
		for (int i = 0; i < tilesX; i += 2) {
			for (int j = 0; j < tilesY; j += 2) {
				BuildBasic(i, j);
			}
		}
	}

	void BuildBasic(int x, int y) {
		Vector3 pos = new Vector3(x * tileWidth, 0, y * tileHeight);
		Instantiate(basicBuilding, pos, Quaternion.identity);
	}
}
