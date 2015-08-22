using UnityEngine;
using System.Collections;

public class GuardAI : MonoBehaviour {

	public GameObject ArrowType;

	public float walkativity = 3f;

	
	public float scareRange = 4f;
	public float bowRange = 6f;
	public float chaseRange = 10f;
	public float caffeinatedness = 0.25f;
	
	public float idleSpeed = 3f;
	public float chargeSpeed = 4.5f;
	public float scaredSpeed = 6f;

	public float shootCooldown = 1f;

	private float shootProgress = 0f;
	private GameObject scaryThing;
	private NavMeshAgent navMeshAgent;
	
	// Use this for initialization
	void Start () {
		scaryThing = GameObject.FindGameObjectWithTag ("Player");
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () {
		float distanceToPlayer = (transform.position - scaryThing.transform.position).magnitude;
		if (distanceToPlayer < scareRange) {
			navMeshAgent.SetDestination (Away (scaryThing.transform.position));
			navMeshAgent.speed = scaredSpeed;
		} else if (distanceToPlayer < bowRange) {
			navMeshAgent.ResetPath();
			Shoot();
		} else if (distanceToPlayer < chaseRange) {
			navMeshAgent.SetDestination (scaryThing.transform.position);
		} else if (navMeshAgent.remainingDistance < caffeinatedness * walkativity) {
			Vector2 randomDestination = Random.insideUnitCircle;
			Vector3 destination = transform.position + new Vector3 (randomDestination.x, 0, randomDestination.y) * walkativity;
			navMeshAgent.SetDestination(destination);
			navMeshAgent.speed = idleSpeed;
		}
	}

	private void Shoot() {
		shootProgress += Time.deltaTime;
		if (shootProgress >= shootCooldown) {
			shootProgress = 0;
			Instantiate (ArrowType, transform.position, Quaternion.LookRotation(scaryThing.transform.position - transform.position));
		}
	}
	
	private Vector3 Away(Vector3 from) {
		return (2 * transform.position - from);
	}
}
