using UnityEngine;

public class FollowCamera : MonoBehaviour {

	public Vector3 offset = new Vector3(0, 15, -40);
	public float stepSize = 0.3f;

	private Player player;

	public void Start() {
		player = GameObject.Find("Player").GetComponent<Player>();

		Vector3 rotatedOffset = player.transform.rotation * offset;
		transform.position = player.transform.position + rotatedOffset;
		transform.rotation = player.transform.rotation;
	}

	public void FixedUpdate() {
		Vector3 rotatedOffset = player.transform.rotation * offset;
		transform.position = Vector3.Lerp(
			transform.position, 
			player.transform.position + rotatedOffset, 
			stepSize);
		transform.rotation = Quaternion.Lerp(
			transform.rotation,
			player.transform.rotation, 
			stepSize);
	}
}
