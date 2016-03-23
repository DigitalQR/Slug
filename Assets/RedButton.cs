using UnityEngine;
using System.Collections;

public class RedButton : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.CompareTag ("Player")) 
		{
			animator.SetTrigger("RedButton");
		}
	}
}
