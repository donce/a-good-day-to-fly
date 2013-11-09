using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	GameObject target;
	
	public Checkpoint next = null;
	
	void Awake() {
		target = GameObject.Find("Camera");
		next = null;
	}
	
	void Update() {
		transform.LookAt(target.transform.position);
	}
	
	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		if (next)
			next.Activate();
		else
			Debug.Log("Finish");
	}
	
	public void Activate() {
		gameObject.SetActive(true);
		GameObject.Find("Player").gameObject.GetComponent<Player>().currentCheckpoint = this;
	}
	
}
