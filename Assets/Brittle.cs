using UnityEngine;
using System.Collections;

public class Brittle : MonoBehaviour {

	public float partsMass = 1f;

	public void Break() {
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<PointsTracker> ().buildingsBroken++;	
		foreach (Transform child in transform) {
			if (child.GetComponent<MeshRenderer>() == null) continue;
			//child.gameObject.AddComponent<Rigidbody>().mass = partsMass;
			//child.gameObject.GetComponent<Rigidbody>().drag = 0;
			//child.gameObject.AddComponent<Heavy>();
			child.gameObject.AddComponent<SplitMeshIntoPolygons>().Break();
		}
		gameObject.transform.DetachChildren();
		Destroy (gameObject);
	}
}
