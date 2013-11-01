using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	
	Vector3 position;
	
	void Start () {
		position = transform.position;
	}
	
	void Update () {
		transform.Rotate(new Vector3(0, 1, 0));
	}
}
