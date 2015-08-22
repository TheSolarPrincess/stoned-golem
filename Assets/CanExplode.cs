using UnityEngine;
using System.Collections;

public class CanExplode : MonoBehaviour {

	public float fuse = 1f;
	public float radius = 5;
	public float force = 5;
	public float upwardBias = 0.5f;

	public void Explode() {
		StartCoroutine (explosion ());
	}

	IEnumerator explosion() {
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		GetComponent<Rigidbody> ().AddTorque (Vector3.one);
		yield return new WaitForSeconds(fuse);

		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		foreach (Collider collider in colliders) {
			if (collider.attachedRigidbody == null) continue;

			collider.attachedRigidbody.AddExplosionForce(force, transform.position, radius, upwardBias);

		}
	}
}
