﻿using UnityEngine;
using System.Collections;

public class Billboarding : MonoBehaviour {
	private Transform cameraTransform;

	void Start() {
		cameraTransform = Camera.main.transform;
	}

	void LateUpdate()
	{
		transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward,
		                 cameraTransform.rotation * Vector3.up);
	}
}
