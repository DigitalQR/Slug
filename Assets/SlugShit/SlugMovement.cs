using UnityEngine;
using System.Collections;

public class SlugMovement : MonoBehaviour {

	public Rigidbody rb;
	public float speed;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
        Vector3 right = -transform.right;
        right.y = 0;
        right.Normalize();
        right.y = rb.velocity.y/speed;

        if (Input.GetKey(KeyCode.W))
		{
			rb.velocity = right * speed;
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.velocity = -right * speed;;
		}
	}
}
