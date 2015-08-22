using UnityEngine;
using System.Collections;

public class CanExplode : MonoBehaviour {

	public float fuse = 0f;
	public float radius = 5;
	public float force = 5;
	public float upwardBias = 0.5f;
	
	public GameObject explosionEffect;

	public void Explode() {
		StartCoroutine (explosion ());
	}

	IEnumerator explosion() {
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		GetComponent<Rigidbody> ().AddTorque (Vector3.one);
		yield return new WaitForSeconds(fuse);

		foreach (Transform child in transform) {
			child.gameObject.AddComponent<Rigidbody>().mass = 1f;
			child.gameObject.AddComponent<SphereCollider>().radius = 0.01f;
			child.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.one * 3);
		}
		gameObject.transform.DetachChildren();

		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		foreach (Collider collider in colliders) {
			if (collider.gameObject.GetComponent<Brittle>() != null)
				collider.gameObject.GetComponent<Brittle>().Break();
		}

		Instantiate (explosionEffect, transform.position, Quaternion.identity);
		foreach (Collider collider in colliders) {
			if (collider.attachedRigidbody != null)
				collider.attachedRigidbody.AddExplosionForce(force, transform.position, radius, upwardBias);
			if (collider.gameObject.GetComponent<Squishy>() != null)
				collider.gameObject.GetComponent<Squishy>().Squish();

		}
		GameObject.Destroy(gameObject.GetComponent<Rigidbody> ());
	}
}
