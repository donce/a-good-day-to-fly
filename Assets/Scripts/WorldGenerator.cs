using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	
	public GameObject[] buildings;
	
	public int width, height;
	public int building_width, building_height;
	
	void Awake() {
		if (buildings.Length > 0)
			Generate();
	}
	
	void Generate() {
		for (int i = 0; i < width; ++i)
			for (int j = 0; j < height; ++j) {
				Vector3 pos = new Vector3(i * building_width, 0, j * building_height);
				Instantiate(buildings[0], pos, Quaternion.identity);
			}
	}
}
