using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Screams : MonoBehaviour {

	public List<AudioClip> clips;
	public float volume=0.2f;

	public void Scream(Vector3 at) {
		AudioSource.PlayClipAtPoint (clips[Random.Range(0, clips.Count)],at, volume);
	}
}
