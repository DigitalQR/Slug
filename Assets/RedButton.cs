using UnityEngine;
using System.Collections;

public class RedButton : MonoBehaviour {

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
		}
	}
}
