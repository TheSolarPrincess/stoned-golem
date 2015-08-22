using UnityEngine;
using System.Collections;

public class PointsTracker : MonoBehaviour {

	public int pointsForCivilian = 100;
	public int pointsForGuard = 150;
	public int pointsForBuilding = 500;

	public int civiliansKilled=0;
	public int guardsKilled=0;
	public int buildingsBroken=0;

	public int PointTotal() {
		return pointsForCivilian * civiliansKilled +
			pointsForGuard * guardsKilled +
			pointsForBuilding * buildingsBroken;
	}
}
