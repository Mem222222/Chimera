using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public GameObject keycard;
    public AudioSource source;
    public AudioClip clip;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Stats statsScript = collider.gameObject.GetComponent<Stats>();

            if (Input.GetKey(KeyCode.E))
            {
                source.PlayOneShot(clip);
                statsScript.keycardLevel++;
                keycard.SetActive(false);
            }
        }
    }
}
