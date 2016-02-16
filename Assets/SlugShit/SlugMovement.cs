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
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();
        forward.y = rb.velocity.y / speed;

        if (Input.GetKey(KeyCode.W))
		{
            rb.velocity = forward * speed;
		}
		if (Input.GetKey(KeyCode.S))
		{
            rb.velocity = -forward * speed; ;
		}
	}
}
