using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCamera : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public Vector3 direction;
    public Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction vector from the camera to the player.
        direction = player.position - transform.position;
        // Calculate the rotation needed to look at the player.
        rotation = Quaternion.LookRotation(direction);
        // Interpolate from the current rotation to the needed rotation.
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        // Always look at the player.
        transform.LookAt(player);
    }
}
