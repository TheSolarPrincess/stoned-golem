using UnityEngine;
using System.Collections;

public class HurtPlayerOnceOnCollide : MonoBehaviour {

	private StabilityTracker tracker;

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player") {
			tracker.HurtWithArrow();
		}
		Destroy (this);
	}

	void Awake() {
		tracker = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StabilityTracker> ();
	}
}
