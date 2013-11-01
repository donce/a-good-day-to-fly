using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	
	int time = 0;
	Vector3 position;
	
	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 1, 0));
		transform.position.Set(position.x, position.y + Mathf.Sin(time), position.z);
		time += 1;
		//transform.localPosition.Set(pos.
	}
}
