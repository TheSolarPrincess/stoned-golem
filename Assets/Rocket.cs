using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	public float power=300f;
	public float adjForGravity=10f;

	void Start() {
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power + Vector3.up * adjForGravity);
	}
}
