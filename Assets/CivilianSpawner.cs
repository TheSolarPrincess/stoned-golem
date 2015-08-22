using UnityEngine;
using System.Collections;

public class CivilianSpawner : MonoBehaviour {
	public GameObject prefabToSpawn;
	public float period=5;
	public float periodVariance=1;

	private float tillNextSpawn;

	void Awake() {
		tillNextSpawn = period + Random.Range (-periodVariance, periodVariance);
	}

	void Update() {
		tillNextSpawn -= Time.deltaTime;
		if (tillNextSpawn <= 0) {
			Spawn ();
			tillNextSpawn = period + Random.Range (-periodVariance, periodVariance);
		}
	}

	private void Spawn() {
		NavMeshHit navmeshHit;
		if (NavMesh.SamplePosition (transform.position, out navmeshHit, 1.0f, NavMesh.AllAreas)) {
			Vector3 newPos = navmeshHit.position;
			Instantiate (prefabToSpawn, newPos, Quaternion.identity);
		}
	}
}
