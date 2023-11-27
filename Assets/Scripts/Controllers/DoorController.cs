using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;

    public AudioClip Open;
    public AudioClip Denied;
    public AudioClip Closed;
    public AudioSource source;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player") 
        {
            Stats statsScript = collision.gameObject.GetComponent<Stats>();
            if (statsScript.keycardLevel >= 1)
            {
                source.PlayOneShot(Open);
                Debug.Log("Door opened");
                Door.SetActive(false);
            }
            else
            {
                source.PlayOneShot(Denied);
                Debug.Log("Player does not have the required keycard level to open the door");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("door");
            Door.SetActive(true);

        }
    }
}
  

