using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StabilityTracker : MonoBehaviour {

	public Text displayText;
	public StabilityBar displayBar;
	public string displayLegend = "Stability: ";
	public float displayMultiplier = 1;
	public float initialStability = 9001;
	public float lossPerSecond = 50;
	public float lossFromArrow = 70;

	public GameObject displayOnGameEnd;
	public float displayDelay = 2f;

	private float stability;

	public bool playerAlive {
		get {
			return (stability <= 0);
		}
	}

	void Start () {
		stability = initialStability;
		displayBar.maxStability = initialStability;
	}
	
	// Update is called once per frame
	void Update () {
		stability -= (lossPerSecond * Time.deltaTime);
		//displayText.text = displayLegend + (displayMultiplier * Mathf.Max (0, (int)stability)).ToString ();
		displayBar.stability = stability;
		if (stability <= 0)
			StopThis ();
	}

	private void StopThis() {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<Movement> ().enabled = false;
		player.GetComponent<CanExplode> ().Explode ();
		StartCoroutine (DisplayScoreboard());
		this.enabled = false;
	}

	private IEnumerator DisplayScoreboard() {
		yield return new WaitForSeconds (displayDelay);
		displayOnGameEnd.SetActive (true);
	}

	public void HurtWithArrow() {
		stability -= lossFromArrow;
	}
}
