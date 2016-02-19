using UnityEngine;
using System.Collections;

public class PlaySoundOnceThenDestroyTheObjectItsAttachedTo : MonoBehaviour {

	AudioSource clip;

	void Start () {
        clip = GetComponent<AudioSource>();
        clip.Play();
	}


	void Update() {
		if (!clip.isPlaying) {
			Destroy(gameObject);
		}
	}
}
