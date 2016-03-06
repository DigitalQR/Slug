using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {


	Rigidbody rb;
	public float rotationSpeed = 4f;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb.rotation = Quaternion.Euler (rb.rotation.eulerAngles + new Vector3
			(0f, rotationSpeed * Input.GetAxis ("Mouse X"), 0f));
	}
}
