using UnityEngine;
using System.Collections;

public class ReloadGame : MonoBehaviour {

	public void Reload() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
