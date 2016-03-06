using UnityEngine;
using Leap;
using System.Collections;

public class SlugMovement : MonoBehaviour {

	Rigidbody rb;
    public Transform LEAP_controller;
	public float speed;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
        Controller controller = new Controller();
        HandList hands = controller.Frame().Hands;
        

        if (hands.Count != 0)
        {
            Hand hand = hands[0];
            Vector3 hand_direction = new Vector3(-hand.PalmPosition.ToUnity().x, hand.PalmPosition.ToUnity().z, hand.PalmPosition.ToUnity().y);
            hand_direction = Camera.main.transform.rotation * hand_direction;

            Vector3 hand_position = LEAP_controller.position + hand_direction;
            


            Vector3 direction = hand_position - transform.position;
            direction.y = 0;
            Debug.DrawRay(transform.position, direction, Color.red);
            direction.Normalize();
            direction.y = rb.velocity.y / speed;

            rb.velocity = direction * speed;
            
        }
	}
}
