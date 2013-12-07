using UnityEngine;

public class Collectable : MonoBehaviour {

	void FixedUpdate() {
		transform.Rotate(new Vector3(0, 1, 0));
	}
	
	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
	}
}
