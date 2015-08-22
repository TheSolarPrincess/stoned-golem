﻿using UnityEngine;
using System.Collections;

public class CivilianAI : MonoBehaviour {

	public float walkativity = 1f;
	public float scareRange = 1f;

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
		}
	}

	private Vector3 Away(Vector3 from) {
		return (2 * transform.position - from);

	}
}
