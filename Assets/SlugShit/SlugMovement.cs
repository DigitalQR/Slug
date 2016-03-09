using UnityEngine;
using Leap;
using System.Collections;

public class SlugMovement : MonoBehaviour
{

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
            Transform camera_transform = Camera.main.transform;

            Vector3 direction = camera_transform.forward;
            if (hands.Count == 2)
            {
                direction *= 0;
            }

            direction.y = 0;
            direction.Normalize();
            direction.y = rb.velocity.y / speed;

            rb.velocity = direction * speed;

        }
    }
}
