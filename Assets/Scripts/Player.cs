using UnityEngine;

public class Player : MonoBehaviour {

	public float minThrust = 2000;
	public float maxThrust = 20000;
	public float torque = 10000;
	public float aerodynamicity = 0.1f;

	private GUIText guiSpeed;
	private ParticleSystem engineL;
	private ParticleSystem engineR;

	public void FixedUpdate() {
		/* Rotation. The ship must have a high angular drag or it will start spinning. */
		rigidbody.AddTorque(transform.right * torque * Input.GetAxis("Pitch"), ForceMode.Force);
		rigidbody.AddTorque(transform.up * torque * Input.GetAxis("Yaw"), ForceMode.Force);
		rigidbody.AddTorque(transform.forward * torque * Input.GetAxis("Roll"), ForceMode.Force);

		/* Aerodynamic force.
		 * An atmosphere-capable spaceship would have to be aerodynamic, right?
		 * I made the formula up so it's probably not realistic but it makes the handling easier..
		 */
		Vector3 aeroNormal = (-rigidbody.velocity.normalized + transform.forward).normalized;
		Vector3 aeroForce = aeroNormal * rigidbody.velocity.magnitude * aerodynamicity;
		rigidbody.AddForce(aeroForce, ForceMode.Force);

		/* Thrust. */
		float thrustInput = (Input.GetAxis("Thrust") + 1) / 2;
		Vector3 force = transform.forward * Mathf.Lerp(minThrust, maxThrust, thrustInput);
		rigidbody.AddForce(force, ForceMode.Force);
	}

}
