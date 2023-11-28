using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public GameObject DoorLight;

    public AudioClip Open;
    public AudioClip Denied;
    public AudioClip DoorLightOn;
    public AudioClip DoorLightOff;
    public AudioClip Closed;
    public AudioSource source;

    private bool isDoorActive = true;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Stats statsScript = collision.gameObject.GetComponent<Stats>();
            if (statsScript.keycardLevel >= 1)
            {
                isDoorActive = false;

                source.PlayOneShot(Open);
                Debug.Log("Door opened");
                Door.SetActive(false);
            }
            else
            {
                source.PlayOneShot(DoorLightOn);
                source.PlayOneShot(Denied);
                Debug.Log("Player does not have the required keycard level to open the door");
                DoorLight.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DoorLight.SetActive(false);
        source.PlayOneShot(DoorLightOff);

        if (collision.gameObject.tag == "Player" && !isDoorActive)
        {
            isDoorActive = true;
            Debug.Log("door closed");
            Door.SetActive(true);
            source.PlayOneShot(Closed);
        }
    }
}
  

