using UnityEngine;
using System.Collections;

public class Squishy : MonoBehaviour {

	public GameObject splat;
	public bool isGuard = false;

	public void Squish() {
		if (isGuard)
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<PointsTracker> ().guardsKilled++;
		else
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<PointsTracker> ().civiliansKilled++;
		splat = Instantiate (splat);
		Vector3 splatPosition = transform.position;
		splatPosition.y = 0.01f;
		splat.transform.position = splatPosition;
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.GetComponent<Heavy> ())
			Squish ();
	}
}
