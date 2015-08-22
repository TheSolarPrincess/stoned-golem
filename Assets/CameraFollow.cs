using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform mainCameraTransform;
	private Vector3 relativePosition;

	void Start () {
		mainCameraTransform = Camera.main.transform;
		relativePosition = mainCameraTransform.position - transform.position;
	}

	void LateUpdate () {
		mainCameraTransform.position = transform.position + relativePosition;
	}
}
