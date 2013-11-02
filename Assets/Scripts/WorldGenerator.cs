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
	
	void BuildObject(int x, int y, int objectNumber) {
		Vector3 pos = new Vector3(x * building_width, 0, y * building_height);
		Instantiate(buildings[objectNumber], pos, Quaternion.identity);
	}
	
	void Generate() {
		for (int i = 0; i < width; ++i)
			for (int j = 0; j < height; ++j)
				BuildObject (i, j, 0);
	}
}
