using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	GameObject target;
	double speed;
	
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Target");
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(target.transform);
		//transform.Rotate(new Vector3(0, 0, 1));
		if (Input.GetKey(KeyCode.A))
			transform.Rotate(new Vector3(0, 0, -1));
		if (Input.GetKey(KeyCode.D))
			transform.Rotate(new Vector3(0, 0, 1));
		if (Input.GetKey(KeyCode.W))
			transform.Rotate(new Vector3(1, 0, 0));
		if (Input.GetKey(KeyCode.S))
			transform.Rotate(new Vector3(-1, 0, 0));
	}
}
