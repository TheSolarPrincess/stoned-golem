using UnityEngine;
using System.Collections;

public class ArrowShoot : MonoBehaviour {

	void Awake () {
		GetComponent<Rigidbody>().AddForce((Vector3.up + Vector3.back) * 1000);
	}
}
