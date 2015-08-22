using UnityEngine;
using System.Collections;

public class CivilianAI : MonoBehaviour {

	public float walkativity = 3f;
	public float scareRange = 4f;
	public float caffeinatedness = 0.125f;

	public float idleSpeed = 3;
	public float scaredSpeed = 5;

	private GameObject scaryThing;
	private NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {
		scaryThing = GameObject.FindGameObjectWithTag ("Player");
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		if ((transform.position - scaryThing.transform.position).magnitude < scareRange) {
			navMeshAgent.SetDestination (Away (scaryThing.transform.position));
			navMeshAgent.speed = scaredSpeed;
		} else if (navMeshAgent.remainingDistance < caffeinatedness * walkativity) {
			Vector2 randomDestination = Random.insideUnitCircle;
			Vector3 destination = transform.position + new Vector3 (randomDestination.x, 0, randomDestination.y) * walkativity;
			navMeshAgent.SetDestination(destination);
			navMeshAgent.speed = idleSpeed;
		}
	}

	private Vector3 Away(Vector3 from) {
		return (2 * transform.position - from);

	}
}
