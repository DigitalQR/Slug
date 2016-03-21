using UnityEngine;
using System.Collections;

public class MovementTesting : MonoBehaviour {

    Rigidbody rb;
    float speed;
    int cooldown = 0;
    float rotation_speed = 4f;
    bool debug_movement = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = GetComponent<SlugMovement>().speed;
    }

    void FixedUpdate()
    {
        if (cooldown != 0)
            cooldown--;

        if (Input.GetKeyDown(KeyCode.M) && cooldown == 0)
        {
            debug_movement = !debug_movement;

            if(debug_movement)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
            Cursor.visible = !debug_movement;

            Debug.Log("Debug Movement: " + debug_movement);
            cooldown = 20;
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

        rb.rotation *= Quaternion.AngleAxis(rotation_speed * Input.GetAxis("Mouse X"), Vector3.up);
        //rb.rotation *= Quaternion.AngleAxis(rotation_speed * Input.GetAxis("Mouse Y"), Vector3.left);
    }

}
