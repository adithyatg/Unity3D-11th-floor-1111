using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatefans : MonoBehaviour
{
    public float rotationSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*rotationSpeed*Time.deltaTime);

    }
}
