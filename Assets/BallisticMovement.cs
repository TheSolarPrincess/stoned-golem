using UnityEngine;
using System.Collections;

/* Math time
 * g - downward acceleration
 * force - the strength of bow
 * length - horizontal distance to target
 * height - vertical distance to target
 *
 * forw - horizontal initial speed
 * upw - vertical initial speed
 * 
 * forw^2 + upw^2 = force^2 (assuming that's how bows work - I am not an archer, though)
 * 
 * Let:
 * 
 * k = (1 + height^2 / length^2)
 * i = g * length
 * j = g^2 * length^2 / 4 - force
 * 
 * then:
 * 
 * forw = sqrt[ (i + sqrt(i^2 - 4kj))/(2k) ]
 * upw = g * length / 2forw - forw * height / length
 * 
 * Phew
 */

public class BallisticMovement : MonoBehaviour {

	public float force = 2;

	private float forw;
	private float upw;

	private bool moving;
	private float time = 0;

	public void Shoot(Vector3 destinationPoint) {
		float g = Physics.gravity.magnitude;
		Vector3 toTarget = (destinationPoint - transform.position);
		float length = (new Vector3 (toTarget.x, toTarget.y, 0)).magnitude;
		float height = (new Vector3 (0,0,toTarget.z)).magnitude;

		float k = (1f + Mathf.Pow (height / length, 2f));
		float i = g * length;
		float j = Mathf.Pow (g * length, 2f) / 4f - force;

		forw = Mathf.Sqrt ((i + Mathf.Sqrt(Mathf.Pow(i,2f)-4f*k*j))/(2f * k));
		upw = g * length / (2f * forw) - height * forw / length;

		moving = true;
		transform.rotation = Quaternion.LookRotation (toTarget, Vector3.up);
	}

	void FixedUpdate() {
		if (moving) {
			Vector3 updPos = new Vector3 (forw, upw+Physics.gravity.magnitude * time, 0);
			Debug.Log(updPos);
			transform.localPosition += updPos;
		}
	}

	void Awake() {
		Shoot (GameObject.FindGameObjectWithTag ("Player").transform.position);
	}
}
