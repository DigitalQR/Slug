using UnityEngine;
using System.Collections;

public class RedButton : MonoBehaviour {

    public GameObject geiger_sound;
    public GameObject explosion;

    GameObject console;
	Animator animator;

	// Use this for initialization
	void Start () {
		console = GameObject.FindGameObjectWithTag ("console");
		animator = console.GetComponent<Animator>();
	}

	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.CompareTag ("Player")) 
		{
			animator.SetTrigger("RedButton");
            Invoke("GeigerSound", 1.6666f);
		}
	}

    void GeigerSound()
    {
        Instantiate(geiger_sound);
        Invoke("Explosion", 4.7f);
    }

    void Explosion()
    {
        Instantiate(explosion);
    }
}
