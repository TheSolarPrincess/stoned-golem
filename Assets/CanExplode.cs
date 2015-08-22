using UnityEngine;
using System.Collections;

public class CanExplode : MonoBehaviour {

	public float fuse = 1f;

	public void Explode() {
		StartCoroutine (explosion ());
	}

	IEnumerator explosion() {
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		GetComponent<Rigidbody> ().AddTorque (Vector3.one);
		yield return new WaitForSeconds(fuse);
		Debug.Log ("Boom");
	}
}
