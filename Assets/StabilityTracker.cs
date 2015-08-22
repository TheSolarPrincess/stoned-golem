using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StabilityTracker : MonoBehaviour {

	public Text displayText;
	public string displayLegend = "Stability: ";
	public float displayMultiplier = 1;
	public float initialStability = 9001;
	public float lossPerSecond = 50;
	public float lossFromArrow = 70;

	private float stability;

	void Start () {
		stability = initialStability;
	}
	
	// Update is called once per frame
	void Update () {
		stability -= (lossPerSecond * Time.deltaTime);
		displayText.text = displayLegend + (displayMultiplier * Mathf.Max (0, (int)stability)).ToString ();
		if (stability <= 0)
			StopThis ();
	}

	private void StopThis() {
		Debug.Log ("Boom!");
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<NavMeshMovementTest> ().enabled = false;
		player.GetComponent<CanExplode> ().Explode ();
		this.enabled = false;
	}

	public void HurtWithArrow() {
		stability -= lossFromArrow;
	}
}
