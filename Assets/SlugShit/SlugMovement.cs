using UnityEngine;
using System.Collections;

public class SlugMovement : MonoBehaviour {

	public Rigidbody rb;
	public float speed;
	public float rotationSpeed = 1f;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		if (Input.GetKey(KeyCode.W))
		{
			rb.velocity = -transform.right * speed;
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.velocity = transform.right * speed;;
		}
	}
}
