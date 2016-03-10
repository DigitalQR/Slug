using UnityEngine;
using System.Collections;

public class MovementTesting : MonoBehaviour {

    Rigidbody rb;
    float speed;
    float rotation_speed = 4f;
    bool debug_movement = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = GetComponent<SlugMovement>().speed;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            debug_movement = !debug_movement;
            Debug.Log("Debug Movement: " + debug_movement);
        }
        

        if (!debug_movement)
            return;

        float speed = this.speed;
        if (Input.GetKey(KeyCode.LeftShift))
            speed *= 10;

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 direction = Camera.main.transform.forward;

            direction.y = 0;
            direction.Normalize();
            direction.y = rb.velocity.y / speed;

            rb.velocity = direction * speed;
        }

        rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3
            (0f, rotation_speed * Input.GetAxis("Mouse X"), 0f));
    }

}
