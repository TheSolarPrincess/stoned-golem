using UnityEngine;
using System.Collections;

public class Brittle : MonoBehaviour {

	public float partsMass = 1f;

	public int pointsForBreak = 500;

	public void Break() {
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<PointsTracker> ().buildingsBroken++;	
		foreach (Transform child in transform) {
			if (child.GetComponent<Collider>() == null) continue;
			child.gameObject.AddComponent<Rigidbody>().mass = partsMass;
		}
		gameObject.transform.DetachChildren();
		Destroy (gameObject);
	}
}
