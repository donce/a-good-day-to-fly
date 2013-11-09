using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	GameObject player;
	
	public Checkpoint next = null;
	
	void Start () {
		player = GameObject.Find("Player");
	}
	
	void Update () {
		transform.LookAt(player.transform.position);
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log(other);
		Destroy(gameObject);
		if (next)
			next.gameObject.SetActive(true);
		else
			Debug.Log("Finish");
	}
	
}
