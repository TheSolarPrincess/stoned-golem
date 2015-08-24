using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Rigidbody rb;
	public Animator anim;

	public float velocity = 5f;
	//public float acceleration = 40f;
	//public float maxVelocity = 40f;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector3 move = new Vector3 (h, 0, v);
		rb.velocity = move * velocity;
		//rb.AddForce(move*acceleration, ForceMode.Acceleration);
		if (move.magnitude > 0.01f) {
			rb.rotation = Quaternion.LookRotation (move, Vector3.up);
			anim.SetBool ("walking", true);
		} else {
			anim.SetBool ("walking", false);
		}
		//if (rb.velocity.magnitude > maxVelocity)
		//	rb.velocity.Scale (Vector3.one * (maxVelocity / rb.velocity.magnitude));
		if (Input.GetAxis ("AttackFist") > 0.01f) {
			anim.SetTrigger ("attack");
		}

	}
}
