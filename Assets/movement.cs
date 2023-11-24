using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class movement : MonoBehaviourPunCallbacks
{
    private float speed = 1f;
    private float rspeed = 5f;
    void start()
    {

    }
    void update()
    {
        

        if (Input.GetKey(KeyCode.C))
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.B))
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

        else if (Input.GetKey(KeyCode.F))
        {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.V))
        {
            transform.Translate(0f, 0f, -speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -rspeed * Time.deltaTime, 0f);
        }

        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, rspeed * Time.deltaTime, 0f);
        }
    }
}
