using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float speed = 10;
	
	const float minSpeed = 10;
	const float maxSpeed = 200;
	const float rotationSpeed = 100;
	const float acceleration = 100;
	
	void Start () {
	}
	
	void Update () {
		float rotation = rotationSpeed * Time.deltaTime;
		if (Input.GetKey(KeyCode.A))
			transform.Rotate(new Vector3(0, -rotation, 0));
		if (Input.GetKey(KeyCode.D))
			transform.Rotate(new Vector3(0, rotation, 0));
		if (Input.GetKey(KeyCode.J))
			transform.Rotate(new Vector3(0, 0, rotation));
		if (Input.GetKey(KeyCode.L))
			transform.Rotate(new Vector3(0, 0, -rotation));
		if (Input.GetKey(KeyCode.W))
			transform.Rotate(new Vector3(-rotation, 0, 0));
		if (Input.GetKey(KeyCode.S))
			transform.Rotate(new Vector3(rotation, 0, 0));
		
		
		if (Input.GetKey(KeyCode.I))
			speed += acceleration * Time.deltaTime;
		if (Input.GetKey(KeyCode.K))
			speed -= acceleration * Time.deltaTime;
		speed = Mathf.Max(minSpeed, speed);
		speed = Mathf.Min(maxSpeed, speed);
		
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
