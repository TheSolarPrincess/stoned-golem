using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class Scoreboard : MonoBehaviour {
	public string header = "You have exploded.\n\nPoints:\n";
	public string civilian = "Civilians killed: ";
	public string guards = "Guards killed: ";
	public string buildings = "Buildings blown up: ";
	public string total = "___________________\nTotal: ";

	public void OnEnable() {
		Text t = GetComponent<Text> ();
		PointsTracker points = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PointsTracker> ();

		StringBuilder builder = new StringBuilder ();

		builder.Append(header).Append('\n');
		builder.Append(civilian).Append(points.civiliansKilled).Append(" X ")
			.Append(points.pointsForCivilian).Append(" = ").Append(points.civiliansKilled * points.pointsForCivilian).Append('\n');
		builder.Append(guards).Append(points.guardsKilled).Append(" X ")
			.Append(points.pointsForGuard).Append(" = ").Append(points.guardsKilled * points.pointsForGuard).Append('\n');
		builder.Append(buildings).Append(points.buildingsBroken).Append(" X ")
			.Append(points.pointsForBuilding).Append(" = ").Append(points.buildingsBroken * points.pointsForBuilding).Append('\n');

		builder.Append (total).Append (points.PointTotal ());

		t.text = builder.ToString ();
	}
}
