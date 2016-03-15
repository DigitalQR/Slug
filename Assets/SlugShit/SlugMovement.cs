using UnityEngine;
using Leap;
using System.Collections;

public class SlugMovement : MonoBehaviour
{

    Rigidbody rb;
    public Transform LEAP_controller;
    public float speed;
    Controller controller;
    GestureList gestures;

    void Start()
    {
        controller = new Controller();
        rb = GetComponent<Rigidbody>();

        controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
        controller.Config.SetFloat("Gesture.Swipe.MinLength", 150.0f);
        controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 1000f);
        controller.Config.Save();
    }

    void FixedUpdate()
    {
       
        HandList hands = controller.Frame().Hands;

        Frame frame = controller.Frame();
        gestures = frame.Gestures();

        if (gestures[0].Type == Gesture.GestureType.TYPE_SWIPE)
        {
            SwipeGesture swipe = new SwipeGesture(gestures[0]);
            Vector swipeDirection = swipe.Direction;
            if(swipeDirection == Vector.Left)
                transform.Translate(new Vector3(-1,0,0));
            else if(swipeDirection == Vector.Right)
                transform.Translate(new Vector3(1, 0, 0));
        }


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
