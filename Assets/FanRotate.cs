using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour
{
    private bool PlayerInZone; // check if the player is in trigger
    private bool isFanRotating; // flag to control animation looping

    public GameObject lightorobj;
    public float animationSpeed = 1.0f; // initial speed of the animation
    public float speedChangeFactor = 2.0f; // factor by which speed changes

    private void Start()
    {
        PlayerInZone = false; // player not in zone
        isFanRotating = false; // animation not looping initially
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.G)) // if in zone and press G key
        {
            isFanRotating = !isFanRotating; // toggle the animation loop flag
            lightorobj.GetComponent<Animator>().speed = animationSpeed; // set the animation speed
            lightorobj.GetComponent<Animator>().Play("FanRotation");
            gameObject.GetComponent<Animator>().Play("buttonOn");
        }
        else if (PlayerInZone && Input.GetKeyDown(KeyCode.H)) // if in zone and press H key
        {
            isFanRotating = false; // stop the animation loop
            lightorobj.GetComponent<Animator>().speed = 1.0f; // reset the animation speed
            lightorobj.GetComponent<Animator>().Play("FanRotation");
            gameObject.GetComponent<Animator>().Play("buttonOff");
        }
        else if (PlayerInZone && Input.GetKeyDown(KeyCode.U)) // if in zone and press U key to increase speed
        {
            // Increase the animation speed by a factor (e.g., 2 times)
            animationSpeed *= speedChangeFactor;
            lightorobj.GetComponent<Animator>().speed = animationSpeed;
        }
        else if (PlayerInZone && Input.GetKeyDown(KeyCode.J)) // if in zone and press J key to decrease speed
        {
            // Decrease the animation speed by the same factor
            animationSpeed /= speedChangeFactor;
            lightorobj.GetComponent<Animator>().speed = animationSpeed;
        }

        // Check if the animation should loop and play it
        if (isFanRotating)
        {
            lightorobj.GetComponent<Animator>().Play("FanRotation");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // if player in zone
        {
            PlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") // if player exits zone
        {
            PlayerInZone = false;
            isFanRotating = false; // stop the animation loop when the player exits the zone
            animationSpeed = 1.0f; // reset the animation speed when the player exits the zone
        }
    }
}
