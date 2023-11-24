using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90.0f; // angle to rotate the door
    public float openSpeed = 2.0f; // speed of the door opening
    public float waitTime = 2.0f; // time to wait before closing the door

    private bool isOpen = false; // whether the door is open
    public float defaultRotationAngle; // initial rotation angle of the door
    public float currentRotationAngle; // current rotation angle of the door
    // Start is called before the first frame update
    void Start()
    {
        // Store the initial rotation angle of the door.
        defaultRotationAngle = transform.eulerAngles.y;
        currentRotationAngle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Only open the door if the player enters the trigger and the door is not already open.
        if (other.CompareTag("Player") && !isOpen)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        isOpen = true;

        // Gradually rotate the door to the open angle.
        while (currentRotationAngle < defaultRotationAngle - openAngle)
        {
            currentRotationAngle -= openSpeed;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentRotationAngle, transform.eulerAngles.z);
            //yield return null;
        }

        // Wait for a while before closing the door.
        yield return new WaitForSeconds(waitTime);

        // Gradually rotate the door back to the closed angle.
        while (currentRotationAngle > defaultRotationAngle)
        {
            currentRotationAngle += openSpeed;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentRotationAngle, transform.eulerAngles.z);
            //yield return null;
        }

        isOpen = false;
    }
}
