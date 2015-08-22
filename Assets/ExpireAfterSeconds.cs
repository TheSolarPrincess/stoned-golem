using UnityEngine;
using System.Collections;

public class ExpireAfterSeconds : MonoBehaviour {
	public float lifetime;
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0)
			Destroy (gameObject);
	}
}
