using UnityEngine;
using System.Collections;

public class StabilityBar : MonoBehaviour {

	public float maxStability;
	public float stability;

	void LateUpdate() {
		transform.localScale = new Vector3 (stability / maxStability,1,1);
	}
}
