using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(player.transform.position);
	}
	void OnTriggerEnter(Collider other) {
		Debug.Log(other);
		Destroy(gameObject);
	}
}
