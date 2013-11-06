using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private float speed = 10;
	
	public float minSpeed = 10;
	public float maxSpeed = 200;
	public float rotationSpeed = 100;
	
	public float acceleration = 100;
	public float slowingSpeed = 20;
	
	void Start () {
	}
	
	void Update () {
		float rotation = rotationSpeed * Time.deltaTime;
		if (Input.GetKey(KeyCode.A))
			rigidbody.transform.Rotate(Vector3.up, -rotation);
		if (Input.GetKey(KeyCode.D))
			rigidbody.transform.Rotate(Vector3.up, rotation);
		if (Input.GetKey(KeyCode.J))
			rigidbody.transform.Rotate(Vector3.forward, rotation);
		if (Input.GetKey(KeyCode.L))
			rigidbody.transform.Rotate(Vector3.forward, -rotation);
		if (Input.GetKey(KeyCode.W))
			rigidbody.transform.Rotate(Vector3.right, rotation);
		if (Input.GetKey(KeyCode.S))
			rigidbody.transform.Rotate(Vector3.right, -rotation);
		
		float speedChange = -slowingSpeed;
		if (Input.GetKey(KeyCode.I))
			speedChange = acceleration;
		if (Input.GetKey(KeyCode.K))
			speedChange = -acceleration;
		speed += speedChange * Time.deltaTime;
		speed = Mathf.Max(minSpeed, speed);
		speed = Mathf.Min(maxSpeed, speed);
		
		rigidbody.transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
