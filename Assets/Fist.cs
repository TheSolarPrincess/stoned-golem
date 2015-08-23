using UnityEngine;
using System.Collections;

public class Fist : MonoBehaviour {

	public Animator anim;
	bool active = false;
	public float power;

	private Collider fistCollider;

	void Start() {
		fistCollider = GetComponent<Collider> ();
	}

	void Update() {
		if (anim)
			active = anim.GetCurrentAnimatorStateInfo (0).IsName ("attack");
		fistCollider.enabled = active;
	}

	void OnTriggerEnter(Collider col) {
		if (active && col.attachedRigidbody != null) {
			col.attachedRigidbody.AddExplosionForce(power, fistCollider.bounds.center, fistCollider.bounds.size.magnitude,0f,ForceMode.Impulse);
		}
	}
}
