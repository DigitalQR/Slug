using UnityEngine;
using System.Collections;

public class PlaySoundThenSpawn : MonoBehaviour {

    public GameObject spawn;
    public bool destroyOnceDone = true;
    AudioSource clip;

    void Start()
    {
        clip = GetComponent<AudioSource>();
        clip.Play();
    }


    void Update()
    {
        if (!clip.isPlaying)
        {
            if(spawn != null) Instantiate(spawn);
            if(destroyOnceDone) Destroy(gameObject);
        }
    }
}
