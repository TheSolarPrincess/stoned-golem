using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGen : MonoBehaviour {
	public List<GameObject> prefabsToInitialize;
	public float verticalOffset = 1f;
	public GameObject generateOnThisPlane;
	public float number = 10;

	void Awake() {
		List<Bounds> occupied = new List<Bounds> ();
		int alreadyGenerated = 0;
		Bounds plane = generateOnThisPlane.GetComponent<Collider> ().bounds;

		while (alreadyGenerated < number) {
			GameObject prefab = prefabsToInitialize[Random.Range(0, prefabsToInitialize.Count)];
			GameObject newObj = Instantiate(prefab);
			float randX = Random.Range(plane.min.x, plane.max.x);
			float randZ = Random.Range(plane.min.z, plane.max.z);
			newObj.transform.position = new Vector3(randX, verticalOffset, randZ);
			newObj.transform.rotation = Quaternion.identity;

			Bounds occupy = newObj.GetComponentInChildren<Collider>().bounds;
			bool valid = true;
			foreach (Bounds bounds in occupied) {
				if (occupy.Intersects(bounds)) {
					valid = false;
					break;
				}
			}
			if (!valid)
				Destroy(newObj);
			else {
				occupied.Add(occupy);
				alreadyGenerated++;
			}
		}
	}
}
