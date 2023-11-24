using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightonoff : MonoBehaviour
{

  //  public GameObject txtToDisplay;             //display the UI text

    private bool PlayerInZone;                  //check if the player is in trigger

    public GameObject lightorobj;

    private void Start()
    {

        PlayerInZone = false;                   //player not in zone       
        //txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.G))           //if in zone and press F key
        {
            lightorobj.SetActive(!lightorobj.activeSelf);
    //        gameObject.GetComponent<AudioSource>().Play();
            
            gameObject.GetComponent<Animator>().Play("buttonOn");

        }
        else if (PlayerInZone && Input.GetKeyDown(KeyCode.H))           //if in zone and press F key
        {
            lightorobj.SetActive(!lightorobj.activeSelf);
            //        gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("buttonOff");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
      //      txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
        //    txtToDisplay.SetActive(false);
        }
    }
}