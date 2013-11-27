using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	void Update () {
		transform.Rotate(new Vector3(0, 1, 0));
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log(other);
		Destroy(gameObject);
	}
}
