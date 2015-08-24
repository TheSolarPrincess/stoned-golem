using UnityEngine;
using System.Collections;

public class CanExplode : MonoBehaviour {

	public float fuse = 0f;
	public float radius = 5;
	public float force = 5;
	public float upwardBias = 0.5f;

	public GameObject parts;
	
	public GameObject explosionEffect;

	public void Explode() {
		StartCoroutine (explosion ());
	}

	IEnumerator explosion() {
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		GameObject.Destroy (GetComponent<Fist> ());
		GameObject.Destroy (GetComponentInChildren<Fist> ());

		GameObject.Destroy(parts.GetComponent<Animator>());
		foreach (Transform child in parts.transform) {
			child.gameObject.AddComponent<Rigidbody>().mass = 1f;
			child.gameObject.AddComponent<SphereCollider>().radius = 0.01f;
			child.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.one * 3);
		}
		gameObject.transform.DetachChildren();
		
		yield return new WaitForSeconds(fuse);
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		foreach (Collider collider in colliders) {
			if (collider.gameObject.GetComponent<Brittle>() != null)
				collider.gameObject.GetComponent<Brittle>().Break();
		}

		Instantiate (explosionEffect, transform.position, Quaternion.identity);
		GetComponent<AudioSource> ().Play ();
		foreach (Collider collider in colliders) {
			if (collider.attachedRigidbody != null)
				collider.attachedRigidbody.AddExplosionForce(force, transform.position, radius, upwardBias);
			if (collider.gameObject.GetComponent<Squishy>() != null)
				collider.gameObject.GetComponent<Squishy>().Squish();

		}
		GameObject.Destroy(gameObject.GetComponent<Rigidbody> ());
	}
}
