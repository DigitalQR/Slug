using UnityEngine;
using System.Collections;

public class PlaySoundOnceThenDestroyTheObjectItsAttachedTo : MonoBehaviour {
	public AudioClip otherClip;
	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
		audio.Play();
	}


	void Update() {
		if (!audio.isPlaying) {
			Destroy(gameObject);
		}
	}
}
