using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    private bool isInBoxCollider = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isInBoxCollider)
        {
            if (Input.GetKey(KeyCode.O))
            {
                // Move the object left (positive Z-axis)
                rb.velocity = new Vector3(0f, rb.velocity.y, moveSpeed);
            }
            else if (Input.GetKey(KeyCode.P))
            {
                // Move the object right (negative Z-axis)
                rb.velocity = new Vector3(0f, rb.velocity.y, -moveSpeed);
            }
            else
            {
                // Stop movement if neither O nor P is pressed
                rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Replace with the actual tag of your box collider
        {
            isInBoxCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Replace with the actual tag of your box collider
        {
            isInBoxCollider = false;
        }
    }
}
