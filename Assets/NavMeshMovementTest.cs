using UnityEngine;
using System.Collections;

public class NavMeshMovementTest : MonoBehaviour {

	private NavMeshAgent navMeshAgent;
	private Rigidbody rb;
	private CharacterController characterController;

	void Start() {
		//characterController = GetComponent<CharacterController> ();
		//navMeshAgent = GetComponent<NavMeshAgent> ();
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector3 move = new Vector3 (h, 0, v);
		//characterController.Move (move);
		//navMeshAgent.Move (move);
		//navMeshAgent.SetDestination (transform.position + move);
		rb.velocity = move*5;
		if (move.magnitude > 0.01f)
			rb.rotation = Quaternion.LookRotation(move, Vector3.up);
	}

	public float pushPower = 2.0f;
	
	public float weight = 6.0f;
	
	//
	// push rigidbodies
	//
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		
		Vector3 force;
		
		// no rigidbody
		if (body == null || body.isKinematic) { return; }
		
		// We use gravity and weight to push things down, we use
		// our velocity and push power to push things other directions
		if (hit.moveDirection.y < -0.3f) 
		{
			force = (new Vector3 (0f, -0.5f, 0f)) * weight;
		}
		else 
		{
			force = hit.controller.velocity * pushPower;
		}
		
		// Apply the push
		body.AddForceAtPosition(force, hit.point);
	}
}
